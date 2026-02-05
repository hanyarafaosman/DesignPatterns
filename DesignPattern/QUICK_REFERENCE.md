# Design Patterns Quick Reference

A quick lookup guide for all 15 design patterns in this repository.

## 🎨 Pattern Categories

### Creational Patterns
**Purpose**: Control object creation mechanisms

| Pattern | Problem | Solution | When to Use |
|---------|---------|----------|-------------|
| **Singleton** | Multiple instances cause inconsistent state | Private constructor + static instance | Config managers, loggers, caches |
| **Factory Method** | Tight coupling to concrete classes | Factory abstracts object creation | Unknown object types at compile time |
| **Builder** | Constructor with too many parameters | Step-by-step object construction | Complex objects with many optional fields |

### Structural Patterns
**Purpose**: Compose objects into larger structures

| Pattern | Problem | Solution | When to Use |
|---------|---------|----------|-------------|
| **Adapter** | Incompatible interfaces | Wrapper translates between interfaces | Integrating legacy/third-party code |
| **Decorator** | Subclass explosion for combinations | Dynamically wrap objects | Extending functionality without inheritance |
| **Facade** | Complex subsystem interactions | Simplified unified interface | Hiding complexity behind simple API |
| **Proxy** | Expensive resource loaded unnecessarily | Lazy loading, access control | Delaying operations, remote objects, security |

### Behavioral Patterns
**Purpose**: Define communication between objects

| Pattern | Problem | Solution | When to Use |
|---------|---------|----------|-------------|
| **Strategy** | Conditional logic for algorithms | Encapsulate algorithms in classes | Multiple ways to do same operation |
| **Observer** | Manual polling for changes | Subjects notify observers automatically | One-to-many dependencies (events) |
| **Command** | Direct method calls couple sender/receiver | Encapsulate requests as objects | Undo/redo, queuing, logging operations |
| **Template Method** | Duplicated algorithm steps | Base class defines skeleton | Common workflow with varying details |
| **State** | State-dependent behavior in conditionals | Each state is a class | Behavior changes with internal state |
| **Chain of Responsibility** | Rigid request handling | Handler chain passes requests | Multiple handlers for one request |
| **Iterator** | Exposing collection internals | Uniform traversal interface | Iterating without exposing structure |
| **Visitor** | Adding operations modifies many classes | Visitor separates algorithm from structure | Operations across diverse object types |

---

## 🔍 Pattern Selection Guide

### When you need to...

#### Control Object Creation
- **One instance only** → Singleton
- **Abstract creation logic** → Factory Method
- **Complex object with many options** → Builder

#### Compose Objects
- **Make incompatible interfaces work** → Adapter
- **Add features dynamically** → Decorator
- **Simplify complex system** → Facade
- **Control access/lazy load** → Proxy

#### Define Object Interactions
- **Switch algorithms at runtime** → Strategy
- **Notify multiple observers** → Observer
- **Encapsulate requests** → Command
- **Define algorithm skeleton** → Template Method
- **Change behavior with state** → State
- **Chain request handlers** → Chain of Responsibility
- **Traverse collections** → Iterator
- **Add operations to structure** → Visitor

---

## 💡 Code Snippets

### Singleton
```csharp
public sealed class Singleton
{
    private static readonly Singleton _instance = new();
    private Singleton() { }
    public static Singleton Instance => _instance;
}
```

### Factory Method
```csharp
public interface IProduct { }
public interface IFactory 
{ 
    IProduct Create(); 
}
```

### Strategy
```csharp
public interface IStrategy 
{ 
    void Execute(); 
}
public class Context
{
    private IStrategy _strategy;
    public Context(IStrategy strategy) => _strategy = strategy;
}
```

### Observer
```csharp
public interface IObserver 
{ 
    void Update(); 
}
public class Subject
{
    private List<IObserver> _observers = new();
    public void Attach(IObserver observer) => _observers.Add(observer);
    public void Notify() => _observers.ForEach(o => o.Update());
}
```

### Decorator
```csharp
public interface IComponent 
{ 
    void Operation(); 
}
public class Decorator : IComponent
{
    private IComponent _component;
    public Decorator(IComponent component) => _component = component;
    public void Operation()
    {
        _component.Operation();
        // Add extra behavior
    }
}
```

### Command
```csharp
public interface ICommand 
{ 
    void Execute(); 
}
public class Invoker
{
    private ICommand _command;
    public void SetCommand(ICommand command) => _command = command;
    public void ExecuteCommand() => _command.Execute();
}
```

---

## 📊 Pattern Relationships

### Complementary Patterns
- **Factory + Singleton**: Factory that returns singleton instances
- **Strategy + Factory**: Factory creates strategy instances
- **Decorator + Factory**: Factory creates decorated objects
- **Command + Composite**: Composite commands (macro commands)
- **Observer + Mediator**: Mediator uses Observer to notify
- **Template Method + Strategy**: Similar but different flexibility

### Alternative Patterns
- **Strategy vs State**: Strategy selects algorithm; State changes behavior
- **Proxy vs Decorator**: Proxy controls access; Decorator adds features
- **Factory vs Builder**: Factory simple creation; Builder complex construction
- **Chain vs Decorator**: Chain processes request; Decorator adds features

---

## 🎯 SOLID Principles Mapping

| Pattern | Principle | How |
|---------|-----------|-----|
| **Factory** | Open/Closed | Add products without modifying factory interface |
| **Strategy** | Open/Closed | Add algorithms without modifying context |
| **Singleton** | Single Responsibility | One class, one instance |
| **Adapter** | Interface Segregation | Client uses specific interface |
| **Decorator** | Single Responsibility | Each decorator adds one responsibility |
| **Observer** | Dependency Inversion | Depend on Observer abstraction |

---

## 🔗 API Endpoints Quick Reference

```bash
# List all patterns
GET /api/patterns

# Run specific pattern
GET /api/patterns/{id}/before      # Problem demo
GET /api/patterns/{id}/after       # Solution demo
GET /api/patterns/{id}/compare     # Side-by-side

# Bulk operations
GET /api/patterns/all              # Run all demos
GET /api/patterns/categories       # Group by type
```

### Pattern IDs
- `singleton`, `factory`, `builder`
- `adapter`, `decorator`, `facade`, `proxy`
- `strategy`, `observer`, `command`, `template`, `state`, `chain`, `iterator`, `visitor`

---

## 📈 Complexity Rating

| Pattern | Complexity | Learning Curve | Use Frequency |
|---------|-----------|----------------|---------------|
| Singleton | ⭐ | Easy | Very High |
| Strategy | ⭐⭐ | Easy | Very High |
| Factory | ⭐⭐ | Easy | High |
| Observer | ⭐⭐ | Medium | High |
| Decorator | ⭐⭐⭐ | Medium | Medium |
| Adapter | ⭐⭐ | Easy | Medium |
| Command | ⭐⭐⭐ | Medium | Medium |
| Template | ⭐⭐ | Easy | Medium |
| Proxy | ⭐⭐⭐ | Medium | Medium |
| Builder | ⭐⭐ | Medium | Medium |
| Facade | ⭐⭐ | Easy | Medium |
| State | ⭐⭐⭐ | Medium | Low |
| Chain | ⭐⭐⭐⭐ | Hard | Low |
| Iterator | ⭐⭐ | Medium | Low (built-in) |
| Visitor | ⭐⭐⭐⭐⭐ | Hard | Low |

---

## 🚀 Learning Path

### Beginner (Start Here)
1. **Singleton** - Simplest pattern
2. **Strategy** - Fundamental behavioral pattern
3. **Factory** - Basic creational pattern

### Intermediate
4. **Observer** - Event-driven programming
5. **Decorator** - Dynamic composition
6. **Adapter** - Interface compatibility
7. **Template Method** - Algorithm structure
8. **Command** - Request encapsulation

### Advanced
9. **Builder** - Complex construction
10. **Proxy** - Access control
11. **Facade** - Subsystem simplification
12. **State** - State machines
13. **Chain** - Request processing
14. **Iterator** - Collection traversal
15. **Visitor** - Operations on structures

---

## 🧪 Testing Checklist

When implementing a pattern:
- [ ] Before demo clearly shows the problem
- [ ] After demo clearly shows the solution
- [ ] Code is self-documenting with comments
- [ ] Runs successfully in console mode
- [ ] Runs successfully in API mode
- [ ] Pattern registered in PatternsController
- [ ] README.md updated with pattern details
- [ ] No compiler warnings or errors

---

**Need details?** See [README.md](README.md) for comprehensive documentation.
