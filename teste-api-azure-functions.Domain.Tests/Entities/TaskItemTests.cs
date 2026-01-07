using teste_api_azure_functions.Domain.Entities;
using teste_api_azure_functions.Domain.Exceptions;
using Xunit;
using System;

namespace teste_api_azure_functions.Domain.Tests.Entities;

public class TaskItemTests
{
    [Fact]
    public void Create_ShouldInitializeTaskWithValidState()
    {
        // Arrange
        string title = "Test Task";
        var dueDate = DateTime.UtcNow.AddDays(5);
        // Act
        TaskItem taskItem = new(title, dueDate);
        // Assert
        Assert.NotEqual(Guid.Empty, taskItem.id);
        Assert.NotEqual(default, taskItem.createdAt);
        Assert.Equal(title, taskItem.title);
        Assert.False(taskItem.isClosed);
    }

    [Fact]
    public void Create_ShouldThrowDomainException_WhenTitleIsEmpty()
    {
        // Arrange
        string invalidTitle = "";
        // Act
        Action actEmpty = () => new TaskItem(invalidTitle);
        // Assert
        Assert.Throws<DomainException>(actEmpty);
    }

    [Fact]
    public void Create_ShouldThrowDomainException_WhenTitleIsNull()
    {
        // Arrange
        string nullTitle = null;
        // Act
        Action actNull = () => new TaskItem(nullTitle);
        // Assert
        Assert.Throws<DomainException>(actNull);
    }

    [Fact]
    public void UpdateDueDate_ShouldChangeDueDate_WhenValidDueDateProvided()
    {
        // Arrange
        TaskItem taskItem = new("Test Task");
        var newDueDate = DateTime.UtcNow.AddDays(10);
        // Act
        taskItem.UpdateDueDate(newDueDate);
        // Assert
        Assert.Equal(newDueDate, taskItem.dueDate);
    }

    [Fact]
    public void UpdateDueDate_ShouldThrowDomainException_WhenDueDateIsBeforeCreatedAt()
    {
        // Arrange
        TaskItem taskItem = new("Test Task");
        var invalidDueDate = taskItem.createdAt.AddDays(-1);

        // Act
        Action act = () => taskItem.UpdateDueDate(invalidDueDate);

        // Assert
        Assert.Throws<DomainException>(act);
    }

    [Fact]
    public void Create_ShouldThrowDomainException_WhenDueDateIsBeforeCreatedAt()
    {
        // arrange
        string title = "Test Task";
        var pastDueDate = DateTime.UtcNow.AddDays(-1);
        // act
        Action act = () => new TaskItem(title, pastDueDate);
        // assert
        Assert.Throws<DomainException>(act);
    }

    [Fact]
    public void UpdateTitle_ShouldChangeTitle_WhenValidTitleProvided()
    {
        // Arrange
        string initialTitle = "Initial Title";
        TaskItem taskItem = new(initialTitle);
        string newTitle = "Updated Title";
        // Act
        taskItem.UpdateTitle(newTitle);
        // Assert
        Assert.Equal(newTitle, taskItem.title);
    }

    [Fact]
    public void UpdateTitle_ShouldThrowDomainException_WhenTitleIsEmpty()
    {
        // Arrange
        string initialTitle = "Initial Title";
        TaskItem taskItem = new(initialTitle);
        string invalidTitle = "";
        // Act
        Action act = () => taskItem.UpdateTitle(invalidTitle);
        // Assert
        Assert.Throws<DomainException>(act);
    }

    [Fact]
    public void UpdateTitle_ShouldThrowDomainException_WhenTitleIsNull()
    {
        // Arrange
        TaskItem taskItem = new("Valid Title");

        // Act
        Action act = () => taskItem.UpdateTitle(null);

        // Assert
        Assert.Throws<DomainException>(act);
    }

    [Fact]
    public void Close_ShouldMarkTaskAsClosed()
    {
        // Arrange
        TaskItem taskItem = new("Test Task");
        // Act
        taskItem.Close();
        // Assert
        Assert.True(taskItem.isClosed);
    }

    [Fact]
    public void Close_ShouldThrowDomainException_WhenTaskIsAlreadyClosed()
    {
        // Arrange
        TaskItem taskItem = new("Test Task");
        taskItem.Close();
        // Act
        Action act = () => taskItem.Close();
        // Assert
        Assert.Throws<DomainException>(act);
    }

    [Fact]
    public void ReOpen_ShouldMarkTaskAsOpen()
    {
        // Arrange
        TaskItem taskItem = new("Test Task");
        taskItem.Close();
        // Act
        taskItem.ReOpen();
        // Assert
        Assert.False(taskItem.isClosed);
    }

    [Fact]
    public void ReOpen_ShouldThrowDomainException_WhenTaskIsAlreadyOpen()
    {
        // Arrange
        TaskItem taskItem = new("Test Task");
        // Act
        Action act = () => taskItem.ReOpen();
        // Assert
        Assert.Throws<DomainException>(act);
    }

    [Fact]
    public void UpdateDescription_ShouldChangeDescription()
    {
        // Arrange
        TaskItem taskItem = new("Test Task");
        string newDescription = "This is a test description.";
        // Act
        taskItem.UpdateDescription(newDescription);
        // Assert
        Assert.Equal(newDescription, taskItem.description);
    }

    [Fact]
    public void UpdateDescription_ShouldAllowNull()
    {
        // Arrange
        TaskItem taskItem = new("Test Task", description: "Initial description");

        // Act
        taskItem.UpdateDescription(null);

        // Assert
        Assert.Null(taskItem.description);
    }

    [Fact]
    public void Restore_ShouldCreateTaskWithProvidedState()
    {
        // Arrange
        var id = Guid.NewGuid();
        var createdAt = DateTime.UtcNow.AddDays(-2);
        var dueDate = DateTime.UtcNow.AddDays(3);
        string title = "Restored Task";
        string description = "Restored description";
        bool isClosed = true;

        // Act
        var taskItem = TaskItem.Restore(
            id,
            title,
            createdAt,
            isClosed,
            dueDate,
            description
        );

        // Assert
        Assert.Equal(id, taskItem.id);
        Assert.Equal(title, taskItem.title);
        Assert.Equal(createdAt, taskItem.createdAt);
        Assert.Equal(dueDate, taskItem.dueDate);
        Assert.Equal(description, taskItem.description);
        Assert.True(taskItem.isClosed);
    }

    [Fact]
    public void Restore_ShouldThrowDomainException_WhenDueDateIsBeforeCreatedAt()
    {
        // Arrange
        var id = Guid.NewGuid();
        var createdAt = DateTime.UtcNow;
        var invalidDueDate = createdAt.AddHours(-1);

        // Act
        Action act = () => TaskItem.Restore(
            id,
            "Invalid Task",
            createdAt,
            false,
            invalidDueDate
        );

        // Assert
        Assert.Throws<DomainException>(act);
    }

    [Fact]
    public void Restore_ShouldThrowDomainException_WhenTitleIsEmpty()
    {
        // Arrange
        var id = Guid.NewGuid();
        var createdAt = DateTime.UtcNow;

        // Act
        Action act = () => TaskItem.Restore(
            id,
            "",
            createdAt,
            false
        );

        // Assert
        Assert.Throws<DomainException>(act);
    }
}