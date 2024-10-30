The SOLID principles are five design principles that help make software more understandable, flexible, and maintainable. Let’s go through each principle, explain its purpose, and show C# code examples that adhere to each principle.

---

### 1. **Single Responsibility Principle (SRP)**

**Definition**: A class should have one, and only one, reason to change. This principle ensures that a class is only responsible for one part of the functionality, making the system easier to maintain and extend.

**Example**: Let's consider a class `Invoice` that manages invoice processing. Without SRP, it might handle data processing, formatting, and logging. To apply SRP, each responsibility should be moved to its own class.

```csharp
// Violates SRP: Handles processing, formatting, and logging in a single class
public class Invoice
{
    public void ProcessInvoice() { /* Processing logic */ }
    public void FormatInvoice() { /* Formatting logic */ }
    public void LogInvoice() { /* Logging logic */ }
}

// Applying SRP: Separate classes for each responsibility
public class InvoiceProcessor
{
    public void ProcessInvoice() { /* Processing logic */ }
}

public class InvoiceFormatter
{
    public void FormatInvoice() { /* Formatting logic */ }
}

public class InvoiceLogger
{
    public void LogInvoice() { /* Logging logic */ }
}
```

By following SRP, each class now has a single responsibility, making the code more modular and testable.

---

### 2. **Open/Closed Principle (OCP)**

**Definition**: Software entities (classes, modules, functions) should be open for extension but closed for modification. This principle helps protect existing code while allowing new functionality to be added.

**Example**: Imagine a discount calculation system that may need new discount strategies in the future. Rather than modifying a single class each time, we can create an interface for discount strategies and extend functionality by adding new classes.

```csharp
// Define an interface for discount calculation
public interface IDiscountStrategy
{
    decimal ApplyDiscount(decimal totalAmount);
}

// Implement different discount strategies without modifying existing classes
public class NoDiscountStrategy : IDiscountStrategy
{
    public decimal ApplyDiscount(decimal totalAmount) => totalAmount;
}

public class SeasonalDiscountStrategy : IDiscountStrategy
{
    public decimal ApplyDiscount(decimal totalAmount) => totalAmount * 0.9m; // 10% off
}

// Main class that applies the discount strategy
public class Invoice
{
    private readonly IDiscountStrategy _discountStrategy;

    public Invoice(IDiscountStrategy discountStrategy)
    {
        _discountStrategy = discountStrategy;
    }

    public decimal CalculateTotal(decimal amount)
    {
        return _discountStrategy.ApplyDiscount(amount);
    }
}
```

Here, we can add more discount strategies in the future without modifying the `Invoice` class, adhering to the Open/Closed Principle.

---

### 3. **Liskov Substitution Principle (LSP)**

**Definition**: Objects of a superclass should be replaceable with objects of subclasses without altering the correctness of the program. This principle ensures that derived classes extend the base class without changing its behavior.

**Example**: Let’s create a base class `Bird` and derive different bird types from it. If we introduce a new class that changes the behavior (e.g., a `Penguin` that can’t fly), it could violate LSP.

```csharp
// Base class for birds
public abstract class Bird
{
    public abstract void Fly();
}

// Derived class that follows LSP
public class Sparrow : Bird
{
    public override void Fly() { Console.WriteLine("Sparrow is flying"); }
}

// Violates LSP as Penguin cannot fly
public class Penguin : Bird
{
    public override void Fly() { throw new NotImplementedException("Penguins can't fly"); }
}
```

To fix this, we can refactor the design by introducing an `IFlyable` interface, applying LSP:

```csharp
public interface IFlyable
{
    void Fly();
}

public abstract class Bird { /* Common bird behavior */ }

public class Sparrow : Bird, IFlyable
{
    public void Fly() { Console.WriteLine("Sparrow is flying"); }
}

public class Penguin : Bird
{
    // No Fly method as Penguins cannot fly, respecting LSP
}
```

By designing the hierarchy this way, we avoid breaking the LSP.

---

### 4. **Interface Segregation Principle (ISP)**

**Definition**: Clients should not be forced to depend on interfaces they do not use. Instead of having large, monolithic interfaces, break them down into smaller, more specific ones.

**Example**: Consider an interface for handling various printer functions. A simple printer may not support all of them, so we can divide the interface into smaller, focused interfaces.

```csharp
// Violates ISP: Forces all printers to implement methods they might not need
public interface IPrinter
{
    void Print();
    void Scan();
    void Fax();
}

// Applying ISP: Separate interfaces for each function
public interface IPrinter
{
    void Print();
}

public interface IScanner
{
    void Scan();
}

public interface IFax
{
    void Fax();
}

// Classes implement only the interfaces they need
public class SimplePrinter : IPrinter
{
    public void Print() { /* Print logic */ }
}

public class MultiFunctionPrinter : IPrinter, IScanner, IFax
{
    public void Print() { /* Print logic */ }
    public void Scan() { /* Scan logic */ }
    public void Fax() { /* Fax logic */ }
}
```

Following ISP allows each printer type to implement only the functionalities it supports, making the code more flexible and maintainable.

---

### 5. **Dependency Inversion Principle (DIP)**

**Definition**: High-level modules should not depend on low-level modules. Both should depend on abstractions. Additionally, abstractions should not depend on details; details should depend on abstractions. DIP promotes decoupling in the system, making it more flexible and easier to change.

**Example**: Let’s create an application where an `OrderService` class relies on a `Logger` to log order details. Instead of depending on a specific `FileLogger`, we depend on an abstraction, allowing for easier substitution if we later want a different logging mechanism.

```csharp
// Define a logging abstraction
public interface ILogger
{
    void Log(string message);
}

// Implement the ILogger interface for a file logger
public class FileLogger : ILogger
{
    public void Log(string message) { Console.WriteLine($"FileLogger: {message}"); }
}

// OrderService depends on ILogger, not a specific logger implementation
public class OrderService
{
    private readonly ILogger _logger;

    public OrderService(ILogger logger)
    {
        _logger = logger;
    }

    public void PlaceOrder()
    {
        // Order placement logic
        _logger.Log("Order placed successfully.");
    }
}
```

Now, if we want to switch to a `DatabaseLogger`, we only need to create a new class implementing `ILogger` without modifying `OrderService`, adhering to DIP.

---

### Summary of SOLID Principles:

1. **Single Responsibility Principle (SRP)**: One reason to change.
2. **Open/Closed Principle (OCP)**: Open for extension, closed for modification.
3. **Liskov Substitution Principle (LSP)**: Derived classes should be substitutable for their base class.
4. **Interface Segregation Principle (ISP)**: Don’t force clients to depend on unused interfaces.
5. **Dependency Inversion Principle (DIP)**: Depend on abstractions, not on concretions.

Applying these principles makes your code easier to read, test, and extend while minimizing the risk of introducing errors when making changes.
