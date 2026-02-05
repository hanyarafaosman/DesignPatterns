# Architecture & Developer Guide

## 🏗️ System Architecture Overview

This project demonstrates a clean, extensible architecture for showcasing design patterns with dual modes:
1. **Console Mode**: Interactive menu for hands-on exploration
2. **API Mode**: RESTful endpoints for testing and integration

### Architecture Diagram

```
┌─────────────────────────────────────────────────────────────┐
│                        Entry Point                          │
│                       (Program.cs)                          │
│                                                             │
│  ┌──────────────────┐         ┌────────────────────────┐  │
│  │  Console Mode    │         │     API Mode           │  │
│  │  (--no args)     │         │     (--api arg)        │  │
│  └────────┬─────────┘         └──────────┬─────────────┘  │
└───────────┼────────────────────────────────┼────────────────┘
            │                                │
            ▼                                ▼
  ┌─────────────────┐          ┌─────────────────────────┐
  │ InteractiveMenu │          │  PatternsController     │
  │      .cs        │          │      (REST API)         │
  └────────┬────────┘          └──────────┬──────────────┘
           │                              │
           │                              │
           ▼                              ▼
  ┌──────────────────────────────────────────────────────┐
  │           Pattern Registry (PatternMap)              │
  │   Dictionary<string, (Name, Before, After, ...)>    │
  └──────────────────┬───────────────────────────────────┘
                     │
                     ▼
  ┌──────────────────────────────────────────────────────┐
  │               Pattern Implementations                │
  │                                                      │
  │  Singleton/   Factory/   Strategy/   Observer/      │
  │  Decorator/   Adapter/   Template/   Command/       │
  │  Proxy/       Iterator/  Builder/    Facade/        │
  │  State/       Chain/     Visitor/                   │
  │                                                      │
  │  Each contains: *Before.cs (problem)                │
  │                 *After.cs  (solution)               │
  └──────────────────────────────────────────────────────┘
```

---

## 📦 Key Components

### 1. Program.cs (Entry Point)
**Responsibility**: Application bootstrap and mode selection

```csharp
static void Main(string[] args)
{
    if (args.Length > 0 && args[0] == "--api")
        RunWebApi(args);      // Start ASP.NET Core API
    else
        InteractiveMenu.Run(); // Start console menu
}
```

**Design Pattern**: Template Method (defines application flow)

---

### 2. InteractiveMenu.cs (Console UI)
**Responsibility**: User interaction for pattern exploration

**Features**:
- Lists all 15 patterns with numbered menu
- Allows running individual Before/After demos
- Option to run all patterns sequentially
- Clear, formatted console output

**Key Methods**:
- `Run()`: Main menu loop
- `DisplayMenu()`: Shows pattern list
- `ExecuteChoice(int choice)`: Runs selected pattern

---

### 3. PatternsController.cs (REST API)
**Responsibility**: HTTP endpoints for pattern testing

**Architecture Pattern**: Registry Pattern

```csharp
// Pattern Registry: Maps IDs to demo methods
Dictionary<string, (string Name, Action Before, Action After, ...)> PatternMap
```

**Endpoints**:
| Method | Endpoint | Purpose |
|--------|----------|---------|
| GET | `/api/patterns` | List all patterns |
| GET | `/api/patterns/{id}/before` | Run problem demo |
| GET | `/api/patterns/{id}/after` | Run solution demo |
| GET | `/api/patterns/{id}/compare` | Side-by-side comparison |
| GET | `/api/patterns/all` | Execute all demos |
| GET | `/api/patterns/categories` | Group by GoF category |

**Design Patterns Used**:
- **Registry Pattern**: PatternMap dictionary
- **Strategy Pattern**: Action delegates for Before/After
- **Facade Pattern**: Simplified API over complex pattern demos

---

### 4. ConsoleOutputCapture.cs (Output Redirection)
**Responsibility**: Capture `Console.WriteLine()` output for API responses

**How It Works**:
```csharp
using (var capture = new ConsoleOutputCapture())
{
    pattern.Before();  // Console output redirected to StringWriter
    var output = capture.GetOutput();  // Retrieve captured text
}
```

**Design Pattern**: Decorator Pattern (wraps Console.Out)

**Implementation**:
- Temporarily replaces `Console.Out` with `StringWriter`
- Restores original output stream when disposed
- Thread-safe for concurrent API requests

---

### 5. Pattern Implementations (Patterns/*)
**Responsibility**: Demonstrate design patterns with Before/After examples

**Structure**:
```
Patterns/
├── Singleton/
│   ├── SingletonBefore.cs   → Problem: Multiple instances
│   └── SingletonAfter.cs    → Solution: Single shared instance
├── Factory/
│   ├── FactoryBefore.cs     → Problem: Tight coupling to concrete classes
│   └── FactoryAfter.cs      → Solution: Factory abstracts creation
└── [13 more patterns...]
```

**Naming Convention**:
- **Before**: Class demonstrating the problem WITHOUT the pattern
- **After**: Class demonstrating the solution WITH the pattern
- Each has a `Demo()` method that outputs to console

---

## 🔧 How the Registry Pattern Works

### Registration (Static Initialization)
```csharp
private static readonly Dictionary<string, (...)> PatternMap = new()
{
    { "singleton", (
        Name: "Singleton",
        Before: Singleton.SingletonBefore.Demo,
        After: Singleton.SingletonAfter.Demo,
        Category: "Creational",
        Description: "Ensures a class has only one instance"
    )},
    // ... 14 more patterns
};
```

### Lookup (Runtime Execution)
```csharp
[HttpGet("{patternId}/before")]
public IActionResult RunBefore(string patternId)
{
    // 1. Lookup pattern by ID
    if (!PatternMap.TryGetValue(patternId.ToLower(), out var pattern))
        return NotFound();

    // 2. Capture output
    using var capture = new ConsoleOutputCapture();
    
    // 3. Execute Before demo
    pattern.Before();  // Invokes Singleton.SingletonBefore.Demo()
    
    // 4. Return output
    return Ok(new { output = capture.GetOutput() });
}
```

**Benefits**:
- ✅ **Open/Closed Principle**: Add patterns without modifying endpoints
- ✅ **DRY**: Single pattern definition used by all endpoints
- ✅ **Type Safety**: Compile-time checks for demo methods
- ✅ **Discoverability**: All patterns in one place

---

## ➕ How to Add a New Pattern

### Step 1: Create Pattern Files
```
Patterns/
└── YourPattern/
    ├── YourPatternBefore.cs   → Problem demo
    └── YourPatternAfter.cs    → Solution demo
```

### Step 2: Implement Before (Problem)
```csharp
namespace DesignPattern.YourPattern.Before
{
    // Demonstrate the problem WITHOUT the pattern
    public static class YourPatternBefore
    {
        public static void Demo()
        {
            Console.WriteLine("YourPatternBefore: Problem demonstration");
            // Show tight coupling, duplication, inflexibility, etc.
        }
    }
}
```

### Step 3: Implement After (Solution)
```csharp
namespace DesignPattern.YourPattern.After
{
    // Demonstrate the solution WITH the pattern
    public static class YourPatternAfter
    {
        public static void Demo()
        {
            Console.WriteLine("YourPatternAfter: Solution demonstration");
            // Show how the pattern solves the problem
        }
    }
}
```

### Step 4: Register in PatternMap
Edit [PatternsController.cs](Controllers/PatternsController.cs):

```csharp
private static readonly Dictionary<...> PatternMap = new()
{
    // ... existing patterns ...
    
    { "yourpattern", (
        "Your Pattern",
        YourPattern.Before.YourPatternBefore.Demo,
        YourPattern.After.YourPatternAfter.Demo,
        "Creational",  // or "Structural" or "Behavioral"
        "Brief description of what your pattern does"
    )},
};
```

### Step 5: Update README.md
Add your pattern to the patterns list with:
- Problem statement
- Solution explanation
- Use cases

### Step 6: Test
```bash
# Console mode
dotnet run
# Select your pattern from menu

# API mode
dotnet run --api
curl http://localhost:5000/api/patterns/yourpattern/compare
```

**That's it!** Your pattern is now:
- ✅ Available in console menu
- ✅ Accessible via REST API
- ✅ Included in `/api/patterns` list
- ✅ Runnable via `/api/patterns/all`

---

## 🎯 Design Decisions

### 1. Why Static Demo Methods?
```csharp
public static void Demo() { ... }
```

**Rationale**:
- ✅ **Simplicity**: No need to instantiate demo classes
- ✅ **Statelessness**: Each demo is independent
- ✅ **Action Delegates**: Easy to store in dictionary
- ✅ **No Side Effects**: Demos don't maintain state

**Alternative Considered**: Interface-based approach
```csharp
interface IPatternDemo { void RunBefore(); void RunAfter(); }
```
❌ Rejected: More boilerplate, requires instantiation

---

### 2. Why Tuple in PatternMap?
```csharp
Dictionary<string, (string Name, Action Before, ...)>
```

**Rationale**:
- ✅ **Named Fields**: Readable property access
- ✅ **Type Safety**: Compile-time checking
- ✅ **Performance**: Value type, no allocation
- ✅ **Clean**: No extra class definition needed

**Alternative Considered**: Custom class
```csharp
class PatternMetadata { string Name; Action Before; ... }
```
❌ Rejected: Overkill for simple data structure

---

### 3. Why Separate Before/After Files?
```
Singleton/
├── SingletonBefore.cs
└── SingletonAfter.cs
```

**Rationale**:
- ✅ **Clarity**: Clear separation of problem vs. solution
- ✅ **Comparison**: Easy to view side-by-side in IDE
- ✅ **Namespaces**: Different classes can use same names
- ✅ **Learning**: Forces explicit problem identification

**Alternative Considered**: Single file with Before/After methods
❌ Rejected: Harder to compare, less modular

---

### 4. Why Console Output Capture?
```csharp
using var capture = new ConsoleOutputCapture();
pattern.Demo();  // Console output redirected
var output = capture.GetOutput();
```

**Rationale**:
- ✅ **Non-Invasive**: Demos don't know about API
- ✅ **Reusability**: Same demos work in Console and API modes
- ✅ **Simplicity**: Demos just use `Console.WriteLine()`
- ✅ **Testing**: Captured output for assertions

**Alternative Considered**: Return strings from demos
❌ Rejected: Forces demos to know about API, less flexible

---

## 🧪 Testing Strategy

### Manual Testing (Console)
```bash
dotnet run
# Test: Navigate menu, run patterns, verify output
```

### Manual Testing (API)
```bash
dotnet run --api
curl http://localhost:5000/api/patterns/singleton/compare
# Test: Verify JSON response, check before/after output
```

### Automated Testing (Future)
```csharp
[Test]
public void Singleton_Before_CreatesMultipleInstances()
{
    using var capture = new ConsoleOutputCapture();
    Singleton.SingletonBefore.Demo();
    var output = capture.GetOutput();
    Assert.Contains("s1.Mode=A", output);
    Assert.Contains("s2.Mode=B", output);
}
```

---

## 🚀 Extension Ideas

### 1. Add Unit Tests
```csharp
// DesignPattern.Tests/
[TestClass]
public class PatternTests
{
    [TestMethod]
    public void AllPatterns_ExecuteWithoutErrors() { ... }
}
```

### 2. Add Swagger Examples
```csharp
[SwaggerOperation(
    Summary = "Run Singleton Before demo",
    Description = "Demonstrates multiple instances with inconsistent state"
)]
[SwaggerResponse(200, "Demo executed successfully", typeof(DemoResult))]
```

### 3. Add Pattern Categories Filter
```csharp
[HttpGet("categories/{category}")]
public IActionResult GetByCategory(string category)
{
    // Return only Creational, Structural, or Behavioral
}
```

### 4. Add Visual Diagrams
- UML class diagrams for each pattern
- Sequence diagrams showing interactions
- Serve as SVG via `/api/patterns/{id}/diagram`

### 5. Add Code Snippets Endpoint
```csharp
[HttpGet("{patternId}/code")]
public IActionResult GetCode(string patternId)
{
    // Return source code for Before and After
}
```

---

## 📊 Performance Considerations

### Memory
- ✅ PatternMap: Static, loaded once
- ✅ Demo methods: Lightweight, no state
- ✅ ConsoleOutputCapture: Disposed after each request

### Concurrency
- ✅ Static demos: Thread-safe (no shared state)
- ✅ Output capture: Per-request isolation
- ✅ API: Stateless, scales horizontally

### Scalability
- ✅ No database: Fast startup, no I/O
- ✅ No external dependencies: Reliable
- ✅ Containerizable: Docker-ready

---

## 🔐 Security Notes

### API Security (Future)
- Add authentication: JWT bearer tokens
- Rate limiting: Prevent abuse
- CORS policy: Restrict origins

### Input Validation
- Pattern ID: Validated against registry
- No user-supplied code execution
- Safe console output capture

---

## 📚 Further Reading

- [Gang of Four Book](https://www.amazon.com/Design-Patterns-Elements-Reusable-Object-Oriented/dp/0201633612)
- [Refactoring Guru](https://refactoring.guru/design-patterns)
- [ASP.NET Core Documentation](https://docs.microsoft.com/aspnet/core)
- [C# Action Delegates](https://docs.microsoft.com/dotnet/api/system.action)

---

**Questions?** Open an issue or contribute improvements! 🎉
