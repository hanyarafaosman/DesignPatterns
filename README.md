# Design Patterns Demo

A comprehensive C# demonstration repository showcasing **15 essential design patterns** with executable before/after examples.

## 🎯 Quick Start

```bash
# Clone the repository
git clone https://github.com/hanyarafaosman/DesignPatterns.git
cd DesignPatterns/DesignPattern

# Run in Console Mode (Interactive Menu)
dotnet run

# Or run in API Mode (REST API + Swagger)
dotnet run --api
# Then open: http://localhost:5000/swagger
```

## 📋 What's Included

- **15 Design Patterns**: Creational, Structural, and Behavioral patterns
- **Before/After Examples**: See the problem and solution side-by-side
- **Two Modes**: Interactive console menu OR REST API
- **Clear Documentation**: Inline comments and comprehensive guides
- **Production-Ready**: Clean architecture, extensible design

## 📁 Project Structure

```
DesignPattern.sln                    # Visual Studio solution
DesignPattern/
├── README.md                        # 📖 Main documentation (START HERE)
├── ARCHITECTURE.md                  # 🏗️ Implementation details
├── CONTRIBUTING.md                  # 🤝 Contribution guidelines
├── Program.cs                       # Entry point
├── Controllers/
│   └── PatternsController.cs       # REST API endpoints
└── Patterns/                        # All pattern implementations
    ├── Singleton/
    │   ├── SingletonBefore.cs      # Problem demo
    │   └── SingletonAfter.cs       # Solution demo
    ├── Factory/
    ├── Strategy/
    ├── Observer/
    └── ... (11 more patterns)
```

## 📚 Documentation

- **[README.md](DesignPattern/README.md)** - Complete user guide with pattern details
- **[ARCHITECTURE.md](DesignPattern/ARCHITECTURE.md)** - Deep dive into system design
- **[CONTRIBUTING.md](DesignPattern/CONTRIBUTING.md)** - How to add patterns or improve code

## 🎓 Patterns Covered

### Creational Patterns (3)
- **Singleton** - Ensure only one instance exists
- **Factory Method** - Delegate object creation to factories
- **Builder** - Construct complex objects step-by-step

### Structural Patterns (4)
- **Adapter** - Convert one interface to another
- **Decorator** - Add responsibilities dynamically
- **Facade** - Simplify complex subsystems
- **Proxy** - Control access to objects

### Behavioral Patterns (8)
- **Strategy** - Encapsulate interchangeable algorithms
- **Observer** - Notify dependents of changes
- **Command** - Encapsulate requests as objects
- **Template Method** - Define algorithm skeleton
- **State** - Change behavior based on state
- **Chain of Responsibility** - Pass requests along chain
- **Iterator** - Traverse collections uniformly
- **Visitor** - Add operations without modifying objects

## 🚀 Features

### Console Mode
- Interactive menu for exploring patterns
- Run patterns individually or all at once
- Clear, formatted output

### API Mode
- RESTful endpoints for all patterns
- Swagger UI for interactive testing
- JSON responses with captured console output
- Compare before/after side-by-side

### Example API Calls
```bash
# List all patterns
curl http://localhost:5000/api/patterns

# Run Singleton demo
curl http://localhost:5000/api/patterns/singleton/compare

# Get patterns by category
curl http://localhost:5000/api/patterns/categories
```

## 🛠️ Requirements

- **.NET 8.0 SDK** or later
- Any IDE: Visual Studio, VS Code, or Rider (optional)

## 🤝 Contributing

Contributions welcome! Please read [CONTRIBUTING.md](DesignPattern/CONTRIBUTING.md) for:
- How to add new patterns
- Code style guidelines
- Testing requirements
- Pull request process

## 📖 Learning Resources

- **Gang of Four**: *Design Patterns: Elements of Reusable Object-Oriented Software*
- **Refactoring Guru**: https://refactoring.guru/design-patterns
- **Head First Design Patterns** by Freeman & Robson

## 📝 License

This project is open source and available under the MIT License.

## 🙏 Acknowledgments

Based on the classic Gang of Four (GoF) design patterns book and inspired by the need for practical, executable examples for learning.

---

**Ready to learn?** Start with the [main README](DesignPattern/README.md) for detailed documentation! 🎉
