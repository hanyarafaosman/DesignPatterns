# Design Patterns Demo

A comprehensive C# demonstration repository showcasing **15 essential design patterns** with before/after examples. Each pattern includes code showing the problem it solves and how the pattern elegantly resolves it.

## 🎓 What You'll Learn

This project demonstrates real-world applications of design patterns through:
- **Side-by-side comparisons**: See the problem (Before) and solution (After) code
- **Interactive exploration**: Console menu or REST API modes
- **Practical examples**: Real scenarios where each pattern shines
- **Clean architecture**: Each pattern isolated in its own namespace

## 📋 Requirements

- **.NET 8.0 SDK** or later
- **Visual Studio 2022** / **Visual Studio Code** / **JetBrains Rider** (optional)
- **curl** or **Postman** for API testing (optional)

## 🚀 Quick Start

### Console Mode (Interactive Menu)
```bash
cd DesignPattern/DesignPattern
dotnet run
```

The interactive menu lets you explore patterns individually or run all demos at once.

### API Mode (Web API for Testing & Debugging)
```bash
cd DesignPattern/DesignPattern
dotnet run --api
```

Access Swagger UI at: **http://localhost:5000**

#### Available Endpoints:
- `GET /api/patterns` — List all patterns
- `GET /api/patterns/{id}/before` — Run "before" demo (problem)
- `GET /api/patterns/{id}/after` — Run "after" demo (solution)
- `GET /api/patterns/{id}/compare` — Compare before/after
- `GET /api/patterns/all` — Run all patterns
- `GET /api/patterns/categories` — Group patterns by category

#### Example API Calls:
```bash
# List all patterns
curl http://localhost:5000/api/patterns

# Run Singleton before demo
curl http://localhost:5000/api/patterns/singleton/before

# Compare Strategy pattern
curl http://localhost:5000/api/patterns/strategy/compare

# Run all patterns
curl http://localhost:5000/api/patterns/all
```

---

## 📋 Patterns Included

### **Creational Patterns** (3 patterns) - Control Object Creation
| Pattern | Purpose | Key Benefit |
|---------|---------|-------------|
| **Singleton** | Ensures single instance | Consistent state, memory efficiency |
| **Factory Method** | Abstracts object creation | Loose coupling, extensibility |
| **Builder** | Constructs complex objects | Readable, flexible construction |

### **Structural Patterns** (4 patterns) - Compose Objects into Structures
| Pattern | Purpose | Key Benefit |
|---------|---------|-------------|
| **Adapter** | Converts interfaces | Integration, reusability |
| **Decorator** | Adds responsibilities dynamically | Flexibility, no inheritance explosion |
| **Facade** | Simplifies complex subsystems | Ease of use, reduced dependencies |
| **Proxy** | Controls access to objects | Lazy loading, security, caching |

### **Behavioral Patterns** (8 patterns) - Define Object Communication
| Pattern | Purpose | Key Benefit |
|---------|---------|-------------|
| **Strategy** | Encapsulates algorithms | Eliminates conditionals, runtime flexibility |
| **Observer** | Notifies dependents automatically | Loose coupling, event-driven |
| **Command** | Encapsulates requests as objects | Undo/redo, queuing, logging |
| **Template Method** | Defines algorithm skeleton | Code reuse, consistent structure |
| **State** | Changes behavior based on state | Eliminates state conditionals |
| **Chain of Responsibility** | Chains request handlers | Flexible handler organization |
| **Iterator** | Traverses collections | Encapsulation, uniform interface |
| **Visitor** | Adds operations to structures | Add operations without modification |

---

## 🌟 Why Use Design Patterns?

### Benefits Overview

**For Code Quality:**
- ✅ **Maintainability** - Patterns create organized, understandable code
- ✅ **Reusability** - Proven solutions can be applied across projects
- ✅ **Testability** - Patterns promote loose coupling and dependency injection
- ✅ **Scalability** - Easier to extend and modify systems

**For Development Process:**
- ✅ **Communication** - Common vocabulary for developers ("use a Factory here")
- ✅ **Best Practices** - Battle-tested solutions to common problems
- ✅ **Faster Development** - Don't reinvent the wheel
- ✅ **Reduced Bugs** - Patterns have been debugged by millions of developers

**SOLID Principles Supported:**
- **Single Responsibility** - Strategy, State, Command, Decorator
- **Open/Closed** - Strategy, Decorator, Factory, Chain
- **Liskov Substitution** - All behavioral patterns with polymorphism
- **Interface Segregation** - Adapter, Facade
- **Dependency Inversion** - Factory, Strategy, Observer

---

## 🎯 Pattern Details with Code Examples

### 1. Singleton Pattern (Creational)

**Problem:** Multiple instances of a class can cause inconsistent state, wasted resources, and synchronization issues.

**Solution:** Ensure a class has only one instance and provide a global access point to it through a private constructor and static instance.

**Key Benefits:**
- ✅ **Controlled access** - Single point of access to the instance
- ✅ **Reduced namespace pollution** - Better than global variables
- ✅ **Memory efficiency** - Only one instance in memory
- ✅ **Consistent state** - All parts of the application see the same data
- ✅ **Lazy initialization** - Instance created only when needed

**When to Use:**
- Configuration managers and application settings
- Logging services
- Database connection pools
- Cache managers
- Thread pools and object pools
- Hardware interface access (printer spooler, device drivers)

**Example:**
```csharp
public sealed class SettingsSingleton
{
    private static readonly SettingsSingleton _instance = new();
    private SettingsSingleton() { }
    public static SettingsSingleton Instance => _instance;
}

// Usage: SettingsSingleton.Instance
```

---

### 2. Factory Method Pattern (Creational)

**Problem:** Creating objects directly with `new` tightly couples code to specific classes, making it hard to change or extend.

**Solution:** Define an interface for creating objects, but let subclasses or factory classes decide which class to instantiate.

**Key Benefits:**
- ✅ **Loose coupling** - Code depends on interfaces, not concrete classes
- ✅ **Open/Closed Principle** - Add new types without modifying existing code
- ✅ **Single Responsibility** - Creation logic separated from business logic
- ✅ **Flexibility** - Easy to change what objects are created
- ✅ **Testability** - Mock factories for unit testing

**When to Use:**
- Unknown object types at compile time
- Creation logic is complex or varies by context
- Need to delegate object instantiation to subclasses
- Framework code that works with user-defined types
- Product families with shared interfaces

**Example:**
```csharp
public interface IProduct { void Use(); }
public interface IFactory { IProduct Create(); }

public class ConcreteFactory : IFactory
{
    public IProduct Create() => new ConcreteProduct();
}
```

---

### 3. Builder Pattern (Creational)

**Problem:** Constructor with many parameters is error-prone, hard to read, and doesn't support optional parameters well.

**Solution:** Construct complex objects step-by-step using a builder interface, separating construction from representation.

**Key Benefits:**
- ✅ **Readable code** - Fluent API makes construction clear
- ✅ **Flexible construction** - Build objects in any order with optional parts
- ✅ **Immutability** - Build once, create immutable objects
- ✅ **Multiple representations** - Same builder can create different representations
- ✅ **Validation** - Validate state before object creation

**When to Use:**
- Objects with many optional parameters
- Complex construction processes with multiple steps
- Different representations of an object
- HTML/XML document builders
- Query builders (SQL, LINQ)
- Configuration objects

**Example:**
```csharp
public class Product
{
    public string PartA { get; set; }
    public string PartB { get; set; }
}

public class Builder
{
    private Product _product = new();
    public Builder AddPartA(string part) { _product.PartA = part; return this; }
    public Builder AddPartB(string part) { _product.PartB = part; return this; }
    public Product Build() => _product;
}

// Usage: new Builder().AddPartA("A").AddPartB("B").Build();
```

---

### 4. Strategy Pattern (Behavioral)

**Problem:** Conditional logic (`if/else` or `switch`) for different algorithms makes code rigid, cluttered, and hard to extend.

**Solution:** Encapsulate each algorithm in its own class implementing a common interface, allowing runtime selection.

**Key Benefits:**
- ✅ **Open/Closed Principle** - Add algorithms without modifying context
- ✅ **Eliminates conditionals** - Cleaner code without if/else chains
- ✅ **Runtime flexibility** - Swap algorithms dynamically
- ✅ **Testability** - Test each strategy independently
- ✅ **Single Responsibility** - Each strategy does one thing

**When to Use:**
- Multiple ways to perform an operation (sorting, compression)
- Algorithm selection at runtime
- Payment processing methods
- Validation rules
- Route calculation (driving, walking, transit)
- Pricing strategies (discount, seasonal)

**Example:**
```csharp
public interface IStrategy { string Execute(string data); }
public class UpperStrategy : IStrategy 
{ 
    public string Execute(string data) => data.ToUpper(); 
}

public class Context
{
    private IStrategy _strategy;
    public Context(IStrategy strategy) => _strategy = strategy;
    public string DoWork(string data) => _strategy.Execute(data);
}
```

---

### 5. Observer Pattern (Behavioral)

**Problem:** Manual polling for changes is inefficient, and tight coupling between objects makes the system brittle.

**Solution:** Define a one-to-many dependency where subjects automatically notify all observers when state changes.

**Key Benefits:**
- ✅ **Loose coupling** - Subjects and observers are independent
- ✅ **Dynamic relationships** - Add/remove observers at runtime
- ✅ **Broadcast communication** - One change notifies many
- ✅ **Event-driven architecture** - Reactive programming support
- ✅ **Reusability** - Observers can work with multiple subjects

**When to Use:**
- UI updates when model changes (MVC, MVVM)
- Event handling systems
- Pub/Sub messaging
- Real-time data feeds (stock prices, notifications)
- Reactive streams
- Change propagation in distributed systems

**Example:**
```csharp
public interface IObserver { void Update(string state); }

public class Subject
{
    private List<IObserver> _observers = new();
    private string _state;
    
    public void Attach(IObserver observer) => _observers.Add(observer);
    public void SetState(string state)
    {
        _state = state;
        _observers.ForEach(o => o.Update(_state));
    }
}
```

---

### 6. Decorator Pattern (Structural)

**Problem:** Subclass explosion when combining features (e.g., 10 features = 1024 subclasses), and inheritance is too static.

**Solution:** Wrap objects with decorator classes that add responsibilities dynamically without changing the original class.

**Key Benefits:**
- ✅ **Open/Closed Principle** - Extend behavior without modification
- ✅ **Flexible** - Add/remove functionality at runtime
- ✅ **Composition over inheritance** - Avoid class explosion
- ✅ **Single Responsibility** - Each decorator adds one feature
- ✅ **Stackable** - Chain multiple decorators

**When to Use:**
- Add features without modifying original class
- Middleware pipelines (ASP.NET Core)
- I/O streams (BufferedStream, GZipStream)
- UI component enhancement
- Logging, caching, validation wrappers
- Coffee shop orders (coffee + milk + sugar)

**Example:**
```csharp
public interface IComponent { void Operation(); }

public class ConcreteComponent : IComponent 
{ 
    public void Operation() => Console.WriteLine("Base"); 
}

public class Decorator : IComponent
{
    private IComponent _component;
    public Decorator(IComponent component) => _component = component;
    public void Operation()
    {
        _component.Operation();
        Console.WriteLine("+ Extra");
    }
}
```

---

### 7. Adapter Pattern (Structural)

**Problem:** Incompatible interfaces prevent classes from working together (legacy code, third-party libraries, different APIs).

**Solution:** Create an adapter class that converts one interface to another, acting as a bridge between incompatible interfaces.

**Key Benefits:**
- ✅ **Interface compatibility** - Make incompatible interfaces work together
- ✅ **Reuse existing code** - Adapt legacy or third-party code
- ✅ **Single Responsibility** - Separate conversion logic
- ✅ **Open/Closed Principle** - Add adapters without modifying adaptee
- ✅ **Multiple adapters** - One class can have many adapters

**When to Use:**
- Integrating legacy systems
- Working with third-party libraries
- Converting data formats (XML to JSON)
- Adapting different APIs
- Database access layers
- Cross-platform compatibility

**Example:**
```csharp
// Existing interface we need to use
public interface ITarget { void Request(); }

// Incompatible class we want to adapt
public class Adaptee { public void SpecificRequest() { } }

// Adapter bridges the gap
public class Adapter : ITarget
{
    private Adaptee _adaptee = new();
    public void Request() => _adaptee.SpecificRequest();
}
```

---

### 8. Facade Pattern (Structural)

**Problem:** Complex subsystems with many classes and interdependencies are difficult to use and understand.

**Solution:** Provide a simplified, unified interface to a set of interfaces in a subsystem, hiding complexity.

**Key Benefits:**
- ✅ **Simplified interface** - Easy to use API for complex systems
- ✅ **Loose coupling** - Clients don't depend on subsystem internals
- ✅ **Layered architecture** - Separate subsystems into layers
- ✅ **Easier testing** - Mock the facade instead of subsystems
- ✅ **Gradual refactoring** - Wrap legacy code with clean interface

**When to Use:**
- Library or framework entry points
- Complex subsystem orchestration
- Database access layers (repositories)
- Payment gateway integration
- Email service wrappers
- External API clients

**Example:**
```csharp
// Complex subsystems
class SubSystemA { public void OperationA() { } }
class SubSystemB { public void OperationB() { } }

// Facade simplifies
public class Facade
{
    private SubSystemA _a = new();
    private SubSystemB _b = new();
    
    public void SimpleOperation()
    {
        _a.OperationA();
        _b.OperationB();
    }
}
```

---

### 9. Proxy Pattern (Structural)

**Problem:** Direct access to an object may be undesirable due to cost (heavy resource), security, or need for additional functionality.

**Solution:** Provide a surrogate or placeholder that controls access to the real object, adding lazy loading, caching, or access control.

**Key Benefits:**
- ✅ **Lazy initialization** - Create expensive objects only when needed
- ✅ **Access control** - Add security checks
- ✅ **Caching** - Store results for performance
- ✅ **Logging** - Track object usage
- ✅ **Remote proxy** - Represent objects in different address spaces

**When to Use:**
- Lazy loading heavy resources (images, databases)
- Virtual proxies for expensive operations
- Protection proxies for access control
- Remote proxies (web services, RMI)
- Caching proxies
- Logging and auditing

**Example:**
```csharp
public interface IService { void Operation(); }

public class RealService : IService
{
    public void Operation() => Console.WriteLine("Expensive operation");
}

public class Proxy : IService
{
    private RealService _real;
    
    public void Operation()
    {
        if (_real == null) _real = new RealService(); // Lazy load
        _real.Operation();
    }
}
```

---

### 10. Template Method Pattern (Behavioral)

**Problem:** Similar algorithms have duplicated code with only minor variations across classes.

**Solution:** Define the skeleton of an algorithm in a base class, letting subclasses override specific steps without changing structure.

**Key Benefits:**
- ✅ **Code reuse** - Common steps in base class
- ✅ **Consistent algorithm** - Structure enforced by template
- ✅ **Open/Closed Principle** - Extend steps without modifying template
- ✅ **Hook methods** - Optional extension points
- ✅ **Inversion of Control** - Framework calls your code

**When to Use:**
- Algorithms with invariant structure
- Framework base classes
- Data processing pipelines
- Testing frameworks (setup, test, teardown)
- Document generators
- Game AI routines

**Example:**
```csharp
public abstract class Algorithm
{
    // Template method defines the skeleton
    public void Execute()
    {
        Step1();
        Step2();  // Varies by subclass
        Step3();
    }
    
    protected void Step1() => Console.WriteLine("Common step 1");
    protected abstract void Step2(); // Subclass implements
    protected void Step3() => Console.WriteLine("Common step 3");
}
```

---

### 11. Command Pattern (Behavioral)

**Problem:** Direct method calls tightly couple the sender to the receiver, making it hard to queue, log, or undo operations.

**Solution:** Encapsulate a request as an object, allowing parameterization of clients with different requests, queuing, and undo/redo.

**Key Benefits:**
- ✅ **Decoupling** - Sender doesn't know about receiver
- ✅ **Undo/Redo** - Store command history
- ✅ **Queuing** - Schedule commands for later execution
- ✅ **Logging** - Record all operations
- ✅ **Macro commands** - Compose commands into sequences
- ✅ **Remote execution** - Send commands over network

**When to Use:**
- Undo/redo functionality
- Transaction systems
- Job queues and schedulers
- GUI buttons and menu items
- Macro recording
- Request logging and auditing

**Example:**
```csharp
public interface ICommand { void Execute(); void Undo(); }

public class ConcreteCommand : ICommand
{
    private Receiver _receiver;
    public ConcreteCommand(Receiver receiver) => _receiver = receiver;
    public void Execute() => _receiver.Action();
    public void Undo() => _receiver.ReverseAction();
}

public class Invoker
{
    private Stack<ICommand> _history = new();
    public void ExecuteCommand(ICommand cmd)
    {
        cmd.Execute();
        _history.Push(cmd);
    }
    public void Undo() => _history.Pop().Undo();
}
```

---

### 12. State Pattern (Behavioral)

**Problem:** Objects with complex state-dependent behavior result in large conditional statements scattered throughout methods.

**Solution:** Allow an object to alter its behavior when its internal state changes by encapsulating states as separate classes.

**Key Benefits:**
- ✅ **Eliminates conditionals** - No more state-dependent if/else
- ✅ **Single Responsibility** - Each state class handles one state
- ✅ **Open/Closed Principle** - Add states without modifying context
- ✅ **Clear state transitions** - Explicit state change logic
- ✅ **Maintainability** - State logic is localized

**When to Use:**
- State machines (workflow, game AI)
- TCP connection states
- Order processing states
- Document approval workflows
- UI component states (enabled, disabled, loading)
- Media player states (playing, paused, stopped)

**Example:**
```csharp
public interface IState { void Handle(Context context); }

public class Context
{
    private IState _state;
    public void SetState(IState state) => _state = state;
    public void Request() => _state.Handle(this);
}

public class ConcreteStateA : IState
{
    public void Handle(Context context)
    {
        Console.WriteLine("State A handling");
        context.SetState(new ConcreteStateB());
    }
}
```

---

### 13. Chain of Responsibility Pattern (Behavioral)

**Problem:** Rigid, centralized request handling makes it hard to add or reorder handlers, and couples sender to receiver.

**Solution:** Chain request handlers together, allowing each handler to process the request or pass it to the next handler.

**Key Benefits:**
- ✅ **Decoupling** - Sender doesn't know which handler will process
- ✅ **Flexibility** - Add, remove, or reorder handlers dynamically
- ✅ **Single Responsibility** - Each handler does one thing
- ✅ **Open/Closed Principle** - Add handlers without modifying chain
- ✅ **Multiple handlers** - Request can be processed by many handlers

**When to Use:**
- Middleware pipelines (ASP.NET Core, Express.js)
- Logging frameworks (log levels chain)
- Support ticket escalation
- Event bubbling in UI
- Request filtering and validation
- Authentication/authorization chains

**Example:**
```csharp
public abstract class Handler
{
    protected Handler _next;
    public void SetNext(Handler next) => _next = next;
    
    public virtual void HandleRequest(int level)
    {
        if (_next != null) _next.HandleRequest(level);
    }
}

public class ConcreteHandler : Handler
{
    public override void HandleRequest(int level)
    {
        if (level < 10)
            Console.WriteLine("Handled by ConcreteHandler");
        else
            base.HandleRequest(level);
    }
}
```

---

### 14. Iterator Pattern (Behavioral)

**Problem:** Exposing internal collection structure (arrays, trees, graphs) breaks encapsulation and limits traversal options.

**Solution:** Provide a uniform way to access elements of a collection sequentially without exposing its underlying representation.

**Key Benefits:**
- ✅ **Encapsulation** - Collection internals remain hidden
- ✅ **Uniform interface** - Same traversal API for different collections
- ✅ **Multiple iterators** - Traverse same collection differently
- ✅ **Simplified collection** - Collection doesn't need traversal logic
- ✅ **Lazy evaluation** - Process elements on-demand

**When to Use:**
- Traversing complex data structures (trees, graphs)
- Multiple traversal algorithms (DFS, BFS)
- Lazy loading large collections
- LINQ queries in C#
- Database result sets
- File system navigation

**Example:**
```csharp
public interface IIterator<T>
{
    bool HasNext();
    T Next();
}

public class Collection<T>
{
    private List<T> _items = new();
    public void Add(T item) => _items.Add(item);
    
    public IIterator<T> CreateIterator() => new ConcreteIterator<T>(_items);
}

// Note: C# has built-in IEnumerable<T> and yield return
```

---

### 15. Visitor Pattern (Behavioral)

**Problem:** Adding new operations to existing object structures requires modifying every class, violating Open/Closed Principle.

**Solution:** Separate algorithms from the objects they operate on by moving operations into visitor classes.

**Key Benefits:**
- ✅ **Open/Closed Principle** - Add operations without modifying elements
- ✅ **Single Responsibility** - Operations grouped by visitor
- ✅ **Double dispatch** - Operation depends on both visitor and element
- ✅ **Accumulate state** - Visitor can maintain state across visits
- ✅ **Related operations together** - All operations in one visitor class

**When to Use:**
- Compiler/interpreter operations (syntax trees)
- Report generation on complex structures
- Export operations (XML, JSON, HTML)
- Serialization/deserialization
- Element validation across object structures
- Calculate aggregate values (sum, statistics)

**Example:**
```csharp
public interface IVisitor
{
    void Visit(ElementA element);
    void Visit(ElementB element);
}

public interface IElement
{
    void Accept(IVisitor visitor);
}

public class ElementA : IElement
{
    public void Accept(IVisitor visitor) => visitor.Visit(this);
}

public class ConcreteVisitor : IVisitor
{
    public void Visit(ElementA element) => Console.WriteLine("Visiting A");
    public void Visit(ElementB element) => Console.WriteLine("Visiting B");
}
```

---

## 🏗️ Project Architecture

```
DesignPattern/
├── Patterns/                       # All pattern implementations
│   ├── Singleton/                  # Single instance patterns
│   │   ├── SingletonBefore.cs     # Problem: Multiple instances
│   │   └── SingletonAfter.cs      # Solution: Singleton pattern
│   ├── Factory/                    # Object creation patterns
│   ├── Strategy/                   # Algorithm encapsulation
│   ├── Observer/                   # Event notification patterns
│   ├── Decorator/                  # Dynamic behavior extension
│   ├── Adapter/                    # Interface compatibility
│   ├── Template/                   # Algorithm skeleton
│   ├── Command/                    # Request encapsulation
│   ├── Proxy/                      # Access control patterns
│   ├── Iterator/                   # Collection traversal
│   ├── Builder/                    # Complex object construction
│   ├── Facade/                     # Simplified interfaces
│   ├── State/                      # State-dependent behavior
│   ├── ChainOfResponsibility/      # Request handling chain
│   └── Visitor/                    # Operations on object structures
│
├── Controllers/                    
│   └── PatternsController.cs      # REST API endpoints
│
├── Program.cs                     # Entry point (Console/API modes)
├── InteractiveMenu.cs             # Interactive console menu
├── PatternsDemo.cs                # Batch demo runner
├── ConsoleOutputCapture.cs        # Captures console for API responses
└── README.md                      # This file
```

### How It Works

1. **Console Mode**: Interactive menu using `InteractiveMenu.cs` lets you explore patterns one-by-one
2. **API Mode**: ASP.NET Core Web API (`PatternsController.cs`) exposes REST endpoints for testing
3. **Pattern Registry**: Controller maintains a dictionary mapping pattern IDs to demo methods
4. **Output Capture**: `ConsoleOutputCapture.cs` redirects console output for API responses

---

## 🧪 Testing Patterns

### Using Console Mode
```bash
dotnet run
# Select pattern number from interactive menu
# Or choose "0" to run all patterns
```

### Using API Mode
```bash
dotnet run --api

# In another terminal:
# List all patterns
curl http://localhost:5000/api/patterns

# Test specific pattern
curl http://localhost:5000/api/patterns/singleton/before
curl http://localhost:5000/api/patterns/singleton/after
curl http://localhost:5000/api/patterns/singleton/compare

# Run all patterns at once
curl http://localhost:5000/api/patterns/all

# Get patterns grouped by category
curl http://localhost:5000/api/patterns/categories
```

### Using Swagger UI
1. Run: `dotnet run --api`
2. Open: http://localhost:5000/swagger
3. Explore and test all endpoints interactively

## 🔍 API Response Format

All pattern endpoints return captured console output:

```json
{
  "pattern": "Singleton",
  "mode": "After",
  "output": "SingletonAfter: Instance.Mode=X\n"
}
```

Comparison endpoint shows both:
```json
{
  "pattern": "Strategy",
  "before": "StrategyBefore A: HELLO\nStrategyBefore B: hello\n",
  "after": "StrategyAfter A: HELLO\nStrategyAfter B: hello\n",
  "explanation": "After: Encapsulates algorithms in separate classes"
}
```
### How It Works

1. **Console Mode**: Interactive menu using `InteractiveMenu.cs` lets you explore patterns one-by-one
2. **API Mode**: ASP.NET Core Web API (`PatternsController.cs`) exposes REST endpoints for testing
3. **Pattern Registry**: Controller maintains a dictionary mapping pattern IDs to demo methods
4. **Output Capture**: `ConsoleOutputCapture.cs` redirects console output for API responses
### 14. Chain of Responsibility
**Problem:** Rigid, centralized request handling logic.  
**Solution:** Handler chain; each handler processes or passes to next.  
**Use When:** Multiple handlers for a request (logging levels, support tiers).

### 15. Visitor
**Problem:** Adding operations requires modifying many classes.  
**Solution:** Visitor separates algorithm from object structure.  
**Use When:** Performing operations across diverse object structures (compilers, reporting).

---

## ⚠️ Common Pitfalls & Best Practices

### When NOT to Use Patterns

**❌ Over-Engineering**
- Don't apply patterns to simple problems that don't need them
- "Hello World" doesn't need a Factory or Strategy pattern
- YAGNI (You Aren't Gonna Need It) - Add patterns when actually needed

**❌ Pattern for the Sake of Patterns**
- Patterns should solve real problems, not be forced
- Don't use Singleton just because you learned it
- Evaluate if the pattern actually improves your code

**❌ Wrong Pattern Selection**
- Using State when you just need simple if/else
- Using Factory when direct instantiation is fine
- Using Visitor for simple operations (overkill)

### Best Practices

**✅ Start Simple**
- Write simple code first
- Refactor to patterns when complexity grows
- Let pain points guide pattern selection

**✅ Understand the Trade-offs**
- Patterns add indirection and complexity
- Balance flexibility vs. simplicity
- More code doesn't always mean better code

**✅ Know Your Patterns**
- Understand WHEN and WHY to use each pattern
- Study real-world examples
- Practice with small projects first

**✅ Combine Patterns**
- Factory + Singleton - Factory returning singleton instances
- Strategy + Factory - Factory creating strategies
- Decorator + Factory - Factory creating decorated objects
- Command + Composite - Macro commands

---

## 💡 Learning Tips

1. **Start with the "Before" code** — understand the problem first
2. **Compare side-by-side** — see how patterns improve design
3. **Experiment** — modify demos and observe changes
4. **Real-world context** — think where you'd apply each pattern

---

## 📚 Resources

### Project Documentation
- **[QUICK_REFERENCE.md](QUICK_REFERENCE.md)** - Quick lookup table for all patterns
- **[ARCHITECTURE.md](ARCHITECTURE.md)** - Deep dive into system architecture  
- **[CONTRIBUTING.md](CONTRIBUTING.md)** - Guidelines for contributors

### External Resources
- **Gang of Four (GoF):** *Design Patterns: Elements of Reusable Object-Oriented Software*
- **Head First Design Patterns** by Freeman & Robson
- **Refactoring Guru:** https://refactoring.guru/design-patterns

---

## 🤝 Contributing

We welcome contributions! Here's how you can help:

### Adding New Patterns
1. Create `YourPattern/YourPatternBefore.cs` and `YourPatternAfter.cs`
2. Register in `PatternsController.cs` PatternMap
3. Add documentation to README.md
4. Test in both Console and API modes

**See [CONTRIBUTING.md](CONTRIBUTING.md) for complete contributor guidelines.**  
**See [ARCHITECTURE.md](ARCHITECTURE.md) for detailed implementation guide.**

### Improving Documentation
- Add more code examples
- Create UML diagrams
- Write blog posts or tutorials
- Translate to other languages

### Reporting Issues
- Found a bug? Open an issue with reproduction steps
- Have a suggestion? Start a discussion

**Pull requests are welcome!** 🎉

---

**Happy Learning! 🎉**

