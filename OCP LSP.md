
---

### Open/Closed Principle (OCP)

**Goal**: The Open/Closed Principle is about **adding new functionality without changing existing code**. This principle is especially important for software that might evolve with new features or requirements. The emphasis is on making your code open for **extension** (adding new behavior) but closed for **modification** (changing existing code), to minimize risk and avoid breaking existing functionality.

**Example**: Let’s consider a notification system that sends notifications via various channels (email, SMS, etc.). If we start with an email-only notification and want to add SMS support later, OCP allows us to add this without changing the existing email notification code.

```csharp
// Base interface for different types of notifications
public interface INotification
{
    void Send(string message);
}

// Email notification, follows OCP by implementing INotification
public class EmailNotification : INotification
{
    public void Send(string message) => Console.WriteLine($"Sending Email: {message}");
}

// To add SMS support, we don’t modify EmailNotification but instead add a new class
public class SmsNotification : INotification
{
    public void Send(string message) => Console.WriteLine($"Sending SMS: {message}");
}

// NotificationService uses INotification, so it’s unaware of specific implementations
public class NotificationService
{
    private readonly INotification _notification;

    public NotificationService(INotification notification)
    {
        _notification = notification;
    }

    public void Notify(string message)
    {
        _notification.Send(message);
    }
}

// Usage
var emailService = new NotificationService(new EmailNotification());
emailService.Notify("Hello via Email");

var smsService = new NotificationService(new SmsNotification());
smsService.Notify("Hello via SMS");
```

Here, the **existing EmailNotification code isn’t modified** when adding `SmsNotification`. We can further extend this system by adding new notification types, each implementing `INotification`, without changing the base classes or services.

---

### Liskov Substitution Principle (LSP)

**Goal**: LSP is about **ensuring that derived classes (subtypes) can be used interchangeably with their base types** without causing unexpected behavior. This principle ensures the correct use of inheritance and focuses on **maintaining a consistent behavior**. Subclasses should only extend the functionality of the base class, not alter its fundamental behavior.

**Example**: Consider a scenario with a class hierarchy for rectangles and squares. Using inheritance, we might initially think it makes sense for a square to inherit from a rectangle, but this could violate LSP.

```csharp
// Rectangle class with width and height
public class Rectangle
{
    public virtual int Width { get; set; }
    public virtual int Height { get; set; }

    public int GetArea() => Width * Height;
}

// Square class inherits Rectangle but behaves unexpectedly
public class Square : Rectangle
{
    public override int Width
    {
        set { base.Width = base.Height = value; }
    }

    public override int Height
    {
        set { base.Width = base.Height = value; }
    }
}

// Client code expecting Rectangle behavior
public class AreaCalculator
{
    public int CalculateArea(Rectangle rectangle)
    {
        rectangle.Width = 4;
        rectangle.Height = 5; // Expecting area to be 4 * 5 = 20
        return rectangle.GetArea();
    }
}

// Usage
var calculator = new AreaCalculator();
var rectangle = new Rectangle();
Console.WriteLine(calculator.CalculateArea(rectangle)); // Output: 20

var square = new Square();
Console.WriteLine(calculator.CalculateArea(square)); // Unexpected Output: 25 (5*5)
```

In this case, `Square` violates LSP because setting width and height independently changes the expected behavior. A square should not behave like a rectangle, which allows different width and height. 

To fix this and comply with LSP, we can separate the shapes without inheriting one from the other:

```csharp
public interface IShape
{
    int GetArea();
}

public class Rectangle : IShape
{
    public int Width { get; set; }
    public int Height { get; set; }
    
    public int GetArea() => Width * Height;
}

public class Square : IShape
{
    public int Side { get; set; }
    
    public int GetArea() => Side * Side;
}
```

Now, both `Rectangle` and `Square` implement `IShape` and provide their specific implementations of `GetArea()`, ensuring consistent behavior when using them interchangeably. 

---

### Key Difference Summarized:

- **OCP** focuses on **extending** the system without modifying existing code. It’s about allowing new functionalities to be added safely.
- **LSP** ensures that **derived classes** remain compatible with the expectations of their base classes, allowing objects to be used interchangeably without altering the intended behavior.

In short, OCP is about making your code easily extendable, while LSP ensures that your derived classes behave correctly without causing surprises.
