# Contributing to Design Patterns Demo

Thank you for your interest in contributing! This project aims to help developers learn design patterns through clear, executable examples.

## 🎯 Ways to Contribute

### 1. Add New Design Patterns
We currently have 15 patterns. Consider adding:
- **Creational**: Abstract Factory, Prototype, Object Pool
- **Structural**: Bridge, Composite, Flyweight
- **Behavioral**: Interpreter, Mediator, Memento
- **Concurrency**: Thread Pool, Read-Write Lock, Monitor Object
- **Architectural**: MVC, MVP, MVVM, Repository

### 2. Improve Existing Examples
- Add more realistic scenarios
- Improve code clarity
- Add comments explaining key concepts
- Simplify complex examples

### 3. Enhance Documentation
- Add UML diagrams
- Create tutorial blog posts
- Add code walkthrough videos
- Translate documentation

### 4. Improve API/Infrastructure
- Add unit tests
- Add integration tests
- Improve error handling
- Add logging
- Create Docker container
- Add CI/CD pipeline

---

## 📝 How to Add a New Pattern

### Step-by-Step Guide

#### 1. Create Pattern Folder
```
Patterns/
└── YourPattern/
    ├── YourPatternBefore.cs   # Problem demonstration
    └── YourPatternAfter.cs    # Solution demonstration
```

#### 2. Implement "Before" (Problem)
```csharp
namespace DesignPattern.YourPattern.Before
{
    /// <summary>
    /// Demonstrates the problem that YourPattern solves.
    /// Show issues like: tight coupling, code duplication, inflexibility
    /// </summary>
    public static class YourPatternBefore
    {
        public static void Demo()
        {
            Console.WriteLine("=== YourPattern Before (Problem) ===");
            
            // Your problem code here
            // Show what's wrong without the pattern
            
            Console.WriteLine();
        }
    }
}
```

#### 3. Implement "After" (Solution)
```csharp
namespace DesignPattern.YourPattern.After
{
    /// <summary>
    /// Demonstrates how YourPattern solves the problem.
    /// Show benefits: loose coupling, DRY, flexibility
    /// </summary>
    public static class YourPatternAfter
    {
        public static void Demo()
        {
            Console.WriteLine("=== YourPattern After (Solution) ===");
            
            // Your solution code here
            // Show how the pattern improves the design
            
            Console.WriteLine();
        }
    }
}
```

#### 4. Register in PatternsController.cs
Add to the `PatternMap` dictionary:
```csharp
private static readonly Dictionary<string, (...)> PatternMap = new()
{
    // ... existing patterns ...
    
    { "yourpattern", (
        "Your Pattern Name",
        YourPattern.Before.YourPatternBefore.Demo,
        YourPattern.After.YourPatternAfter.Demo,
        "Creational",  // or "Structural" or "Behavioral"
        "Brief one-line description of what the pattern does"
    )},
};
```

#### 5. Document in README.md
Add to the pattern details section:
```markdown
### N. Your Pattern
**Problem:** Describe the problem this pattern solves.  
**Solution:** Explain how the pattern addresses it.  
**Use When:** Real-world scenarios where this pattern is useful.

**Before (Problem):**
```csharp
// Problem code snippet
```

**After (Solution):**
```csharp
// Solution code snippet
```
```

#### 6. Test Your Pattern
```bash
# Test in console mode
dotnet run
# Select your pattern from menu

# Test in API mode
dotnet run --api
curl http://localhost:5000/api/patterns/yourpattern/before
curl http://localhost:5000/api/patterns/yourpattern/after
curl http://localhost:5000/api/patterns/yourpattern/compare
```

---

## ✅ Code Style Guidelines

### General Principles
- **Keep it simple**: Examples should be easy to understand
- **Be explicit**: Don't use clever tricks that obscure the pattern
- **Stay focused**: Show ONLY what's relevant to the pattern
- **Add comments**: Explain WHY, not just WHAT

### C# Conventions
- Use C# 12 features when appropriate
- Follow Microsoft C# coding conventions
- Use `var` for obvious types
- Use expression-bodied members for simple properties/methods
- Keep methods short (< 20 lines ideally)

### Naming Conventions
- Pattern folders: PascalCase (e.g., `Singleton/`, `ChainOfResponsibility/`)
- Files: `PatternNameBefore.cs`, `PatternNameAfter.cs`
- Classes: `PatternNameBefore`, `PatternNameAfter`
- Demo method: Always `public static void Demo()`

### Example Structure
```csharp
// BAD: Too complex, hard to understand
public class ComplexExample
{
    private readonly IService<T>[] services;
    public void Execute() => services.ForEach(s => s.Process());
}

// GOOD: Clear, focused on pattern
public class SimpleExample
{
    public void Execute()
    {
        Console.WriteLine("Before: Tight coupling");
        var service = new ConcreteService();  // Problem
        service.DoWork();
    }
}
```

---

## 🧪 Testing Requirements

Before submitting a pull request:

### 1. Manual Testing
- ✅ Pattern runs successfully in console mode
- ✅ Pattern runs successfully in API mode
- ✅ Before demo clearly shows the problem
- ✅ After demo clearly shows the solution
- ✅ No exceptions or errors
- ✅ Output is clear and informative

### 2. Code Quality
- ✅ No compiler warnings
- ✅ Code follows style guidelines
- ✅ Comments explain non-obvious logic
- ✅ No hardcoded values (use constants)
- ✅ Proper exception handling if needed

### 3. Documentation
- ✅ README.md updated with pattern details
- ✅ Code comments added for complex logic
- ✅ Pattern registered in PatternsController
- ✅ Pattern appears in Swagger UI

---

## 📥 Submitting a Pull Request

### 1. Fork & Clone
```bash
git clone https://github.com/your-username/DesignPatterns.git
cd DesignPatterns
```

### 2. Create Feature Branch
```bash
git checkout -b add-pattern-yourpattern
# or
git checkout -b improve-singleton-example
```

### 3. Make Changes
- Implement your pattern or improvement
- Test thoroughly (console + API modes)
- Update documentation

### 4. Commit Changes
```bash
git add .
git commit -m "Add YourPattern design pattern with before/after examples"
```

Use clear commit messages:
- ✅ `Add Prototype pattern with cloning examples`
- ✅ `Improve Singleton documentation with thread-safety notes`
- ✅ `Fix bug in Observer pattern AfterDemo`
- ❌ `Update stuff`
- ❌ `WIP`

### 5. Push & Create PR
```bash
git push origin add-pattern-yourpattern
```

Then create a Pull Request on GitHub with:
- **Title**: Clear description of change
- **Description**: 
  - What pattern/improvement you added
  - Why it's valuable
  - How you tested it
  - Screenshots if applicable

---

## 🐛 Reporting Issues

### Before Reporting
1. Check if issue already exists
2. Try to reproduce in latest version
3. Gather relevant information

### Issue Template
```markdown
## Description
Clear description of the issue

## Steps to Reproduce
1. Run `dotnet run`
2. Select pattern X
3. Observe error Y

## Expected Behavior
What should happen

## Actual Behavior
What actually happens

## Environment
- OS: Windows 11 / macOS 14 / Ubuntu 22.04
- .NET Version: 8.0
- Branch: main

## Screenshots
If applicable
```

---

## 💡 Suggestions for First-Time Contributors

### Easy Tasks
- Add comments to existing patterns
- Fix typos in documentation
- Improve error messages
- Add console colors for better readability

### Medium Tasks
- Add a new simple pattern (e.g., Prototype)
- Create UML diagrams for existing patterns
- Add unit tests for controllers
- Improve API response format

### Advanced Tasks
- Add comprehensive pattern (e.g., Mediator)
- Create interactive Swagger examples
- Add performance benchmarks
- Create Docker container

---

## 📞 Getting Help

- **Questions?** Open a discussion on GitHub
- **Stuck?** Check [ARCHITECTURE.md](ARCHITECTURE.md) for detailed implementation guide
- **Need clarification?** Comment on relevant issue or PR

---

## 🙏 Code of Conduct

- Be respectful and inclusive
- Provide constructive feedback
- Focus on the code, not the person
- Help newcomers get started
- Celebrate contributions, big or small

---

## 📜 License

By contributing, you agree that your contributions will be licensed under the same license as this project.

---

**Thank you for contributing to Design Patterns Demo!** 🎉

Your contributions help developers worldwide learn design patterns through practical examples.
