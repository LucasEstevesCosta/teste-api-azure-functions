using Moq;
using teste_api_azure_functions.Application.Services.TaskItems;
using teste_api_azure_functions.Domain.Entities;
using teste_api_azure_functions.Domain.Interfaces;

namespace teste_api_azure_functions.Application.Tests.TaskItems;

public class GetAllTaskItemsServiceTests
{
    [Fact]
    public async Task ExecuteAsync_WhenTasksExist_ReturnMappedDTOs()
    {
        // Arrange
        var task1 = new TaskItem(title: "Task 1", description: "Description 1");
        var task2 = new TaskItem(title: "Task 2", description: "Description 2");
        var tasksFromRepsitory = new List<TaskItem> { task1, task2 };

        var repositoryMock = new Mock<ITaskItemRepository>();
        var service = new GetAllTaskItemsService(repositoryMock.Object);

        repositoryMock
            .Setup(mock => mock.GetAllAsync())
            .ReturnsAsync(tasksFromRepsitory);

        // Act
        var result = await service.ExecuteAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(tasksFromRepsitory.Count, result.Count);

        Assert.Equal(task1.id, result[0].id);
        Assert.Equal(task1.title, result[0].title);

        Assert.Equal(task2.id, result[1].id);
        Assert.Equal(task2.title, result[1].title);

        repositoryMock.Verify(
            repo => repo.GetAllAsync(),
            Times.Once
        );
    }

    [Fact]
    public async Task ExecuteAsync_WhenTasksDoNotExist_ReturnEmptyList()
    {
        // Arrange
        var tasksFromRepsitory = new List<TaskItem>();

        var repositoryMock = new Mock<ITaskItemRepository>();

        repositoryMock
            .Setup(repo => repo.GetAllAsync())
            .ReturnsAsync(tasksFromRepsitory);

        var service = new GetAllTaskItemsService(repositoryMock.Object);

        // Act
        var result = await service.ExecuteAsync();

        // Assert
        Assert.Empty(result);
    }
}