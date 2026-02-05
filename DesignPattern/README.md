# Design Patterns Demo

A comprehensive C# demonstration repository showcasing **15 essential design patterns** with before/after examples. Each pattern includes code showing the problem it solves and how the pattern elegantly resolves it.

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

### **Creational Patterns** (Object Creation)
- **Singleton** — Ensures a class has only one instance
- **Factory Method** — Delegates object creation to subclasses/factories
- **Builder** — Constructs complex objects step-by-step

### **Structural Patterns** (Object Composition)
- **Adapter** — Converts one interface to another
- **Decorator** — Adds responsibilities dynamically
- **Facade** — Simplifies complex subsystems
- **Proxy** — Controls access to another object (lazy loading, access control)

### **Behavioral Patterns** (Object Interaction)
- **Strategy** — Encapsulates interchangeable algorithms
- **Observer** — Notifies dependents of state changes
- **Command** — Encapsulates requests as objects
- **Template Method** — Defines algorithm skeleton, subclasses fill steps
- **State** — Changes behavior based on internal state
- **Chain of Responsibility** — Passes requests along a handler chain
- **Iterator** — Accesses elements sequentially without exposing structure
- **Visitor** — Adds operations to objects without modifying them

---

## 🎯 Pattern Details

### 1. Singleton
**Problem:** Multiple instances cause inconsistent state (e.g., config settings, database connections).  
**Solution:** Private constructor + static instance ensures single shared object.  
**Use When:** You need exactly one instance (logging, caching, thread pools).

### 2. Factory Method
**Problem:** Client code tightly coupled to concrete classes (`new CarImpl()`).  
**Solution:** Factory abstraction creates objects; client depends on interface.  
**Use When:** Object creation logic is complex or varies by context.

### 3. Strategy
**Problem:** Conditional logic (`if/else`) for different algorithms clutters code.  
**Solution:** Encapsulate each algorithm in a class; swap at runtime.  
**Use When:** Multiple ways to perform an operation (sorting, compression, validation).

### 4. Observer
**Problem:** Manual polling or tight coupling for event notification.  
**Solution:** Subjects notify observers automatically on state change.  
**Use When:** One-to-many dependency (UI updates, event systems).

### 5. Decorator
**Problem:** Subclass explosion for feature combinations (e.g., CoffeeWithMilkAndSugar).  
**Solution:** Wrap objects with decorators to add responsibilities dynamically.  
**Use When:** Extending functionality without modifying original class.

### 6. Adapter
**Problem:** Incompatible interfaces prevent collaboration (XML source, JSON client).  
**Solution:** Adapter wraps the incompatible class and translates calls.  
**Use When:** Integrating legacy code or third-party libraries.

### 7. Template Method
**Problem:** Duplicated algorithm steps across similar classes.  
**Solution:** Base class defines skeleton; subclasses override specific steps.  
**Use When:** Common workflow with varying details (data processing, testing frameworks).

### 8. Command
**Problem:** Direct method calls tightly couple sender and receiver.  
**Solution:** Encapsulate requests as command objects.  
**Use When:** Queuing operations, undo/redo, macro recording.

### 9. Proxy
**Problem:** Heavy resource loaded even when not used.  
**Solution:** Proxy controls access (lazy loading, caching, access control).  
**Use When:** Delaying expensive operations, remote objects, security.

### 10. Iterator
**Problem:** Exposing internal collection structure (arrays, lists).  
**Solution:** Uniform traversal interface hides implementation.  
**Use When:** Iterating collections without exposing internals.

### 11. Builder
**Problem:** Constructor with many parameters is error-prone and unreadable.  
**Solution:** Fluent builder API constructs objects step-by-step.  
**Use When:** Complex objects with optional parameters (HTML builders, query builders).

### 12. Facade
**Problem:** Client must know complex subsystem interactions.  
**Solution:** Simplified interface hides subsystem complexity.  
**Use When:** Simplifying library usage, providing high-level API.

### 13. State
**Problem:** State-dependent behavior scattered in conditionals.  
**Solution:** Each state is a class; object delegates to current state.  
**Use When:** Object behavior changes with internal state (workflows, TCP connections).

### 14. Chain of Responsibility
**Problem:** Rigid, centralized request handling logic.  
**Solution:** Handler chain; each handler processes or passes to next.  
**Use When:** Multiple handlers for a request (logging levels, support tiers).

### 15. Visitor
**Problem:** Adding operations requires modifying many classes.  
**Solution:** Visitor separates algorithm from object structure.  
**Use When:** Performing operations across diverse object structures (compilers, reporting).

---

## 🏗️ Project Structure

```
Patterns/
├── Singleton/          SingletonBefore.cs, SingletonAfter.cs
├── Factory/            FactoryBefore.cs, FactoryAfter.cs
├── Strategy/           StrategyBefore.cs, StrategyAfter.cs
├── Observer/           ObserverBefore.cs, ObserverAfter.cs
├── Decorator/          DecoratorBefore.cs, DecoratorAfter.cs
├── Adapter/            AdapterBefore.cs, AdapterAfter.cs
├── Template/           TemplateBefore.cs, TemplateAfter.cs
├── Command/            CommandBefore.cs, CommandAfter.cs
├── Proxy/              ProxyBefore.cs, ProxyAfter.cs
├── Iterator/           IteratorBefore.cs, IteratorAfter.cs
├── Builder/            BuilderBefore.cs, BuilderAfter.cs
├── Facade/             FacadeBefore.cs, FacadeAfter.cs
├── State/              StateBefore.cs, StateAfter.cs
├── ChainOfResponsibility/ ChainBefore.cs, ChainAfter.cs
└── Visitor/            VisitorBefore.cs, VisitorAfter.cs

Program.cs          — Entry point (runs interactive menu)
InteractiveMenu.cs  — Interactive pattern explorer
PatternsDemo.cs     — Runs all demos sequentially
```

---

## 💡 Learning Tips

1. **Start with the "Before" code** — understand the problem first
2. **Compare side-by-side** — see how patterns improve design
3. **Experiment** — modify demos and observe changes
4. **Real-world context** — think where you'd apply each pattern

---

## 📚 Resources

- **Gang of Four (GoF):** *Design Patterns: Elements of Reusable Object-Oriented Software*
- **Head First Design Patterns** by Freeman & Robson
- **Refactoring Guru:** https://refactoring.guru/design-patterns

---

## 🤝 Contributing

Feel free to add more patterns, improve examples, or suggest real-world scenarios!

---

**Happy Learning! 🎉**

