<!--!
\file README.md
\brief Dreamine.MVVM.Attributes - Attribute definitions used by Dreamine MVVM code generation.
\details This document explains package purpose, installation, architecture intent, usage examples, and attribute reference.
\author Dreamine
\date 2026-03-08
\version 1.0.4
-->

# Dreamine.MVVM.Attributes

**Dreamine.MVVM.Attributes** is a **lightweight attribute library** used by the Dreamine MVVM ecosystem.

This package does **not** implement MVVM behavior by itself.  
Instead, it provides the **declarative markers** consumed by Dreamine tooling such as source generators and supporting runtime modules.

It is designed to reduce repetitive ViewModel code while keeping the codebase **explicit, readable, and maintainable**.

[➡️ 한국어 문서 보기](README_KO.md)

---

## What this library solves

In MVVM projects, repetitive patterns appear frequently:

- private field → public property conversion
- method → command property conversion
- ViewModel ↔ Model proxy mapping
- entry class or structural role marking
- command methods that forward calls to event/service targets

This package standardizes those patterns through **attributes only**, so the higher-level Dreamine tooling can generate the required code consistently.

---

## Key Features

- Attribute-only package with **low dependency footprint**
- Designed for **Dreamine MVVM source-generation workflows**
- Supports property generation markers
- Supports command generation markers
- Supports entry/model/event structural markers
- Supports ViewModel → Model proxy property mapping
- Targets **netstandard2.0** for broad compatibility

---

## Requirements

- **Target Framework**: `netstandard2.0`
- Typically used together with:
  - Dreamine MVVM generator packages
  - Dreamine MVVM runtime/core packages
  - WPF or other .NET desktop MVVM projects

---

## Installation

### Option A) NuGet

```bash
dotnet add package Dreamine.MVVM.Attributes
```

### Option B) PackageReference

```xml
<ItemGroup>
  <PackageReference Include="Dreamine.MVVM.Attributes" Version="1.0.4" />
</ItemGroup>
```

---

## Project Structure

```text
Dreamine.MVVM.Attributes
├── DreamineCommandAttribute.cs
├── DreamineEntryAttribute.cs
├── DreamineEventAttribute.cs
├── DreamineModelAttribute.cs
├── DreamineModelPropertyAttribute.cs
├── DreaminePropertyAttribute.cs
└── RelayCommandAttribute.cs
```

---

## Architecture Role

This package belongs to the **declaration layer** of the Dreamine MVVM stack.

```text
ViewModel Source Code
        │
        ├─ Dreamine.MVVM.Attributes
        │     (markers / metadata)
        │
        ├─ Dreamine Generator
        │     (code generation)
        │
        └─ Dreamine Runtime/Core
              (execution / MVVM infrastructure)
```

The attributes declare **intent**, while other Dreamine packages implement the actual behavior.

---

## Quick Start

### 1) Property generation marker

```csharp
using Dreamine.MVVM.Attributes;

public partial class MainViewModel
{
    [DreamineProperty]
    private string _title;
}
```

Typical intent:

- field-based declaration
- generated public property
- property change notification handled by generator/runtime

---

### 2) Command generation marker

```csharp
using Dreamine.MVVM.Attributes;

public partial class MainViewModel
{
    [RelayCommand]
    private void Save()
    {
    }
}
```

Typical intent:

- method marked as command source
- command property generated automatically
- command naming defaults to `{MethodName}Command`

---

### 3) Entry marker

```csharp
using Dreamine.MVVM.Attributes;

[DreamineEntry]
public partial class MainViewModel
{
}
```

Typical intent:

- marks a primary entry class
- useful for discovery/bootstrap scenarios

---

### 4) Model proxy mapping marker

```csharp
using Dreamine.MVVM.Attributes;

public partial class MainViewModel
{
    [DreamineModelProperty]
    private string _readme;
}
```

Typical intent:

- bind a ViewModel field to a Model property proxy
- generator maps the property to `Model.Readme` or a specified model property

---

### 5) Forwarding command marker

```csharp
using Dreamine.MVVM.Attributes;

public partial class MainViewModel
{
    [DreamineCommand("Event.ReadmeClick", BindTo = "Readme")]
    partial void LoadReadme();
}
```

Typical intent:

- generate a command or forwarding call
- invoke target method path such as `Event.*` or `Service.*`
- optionally assign the returned value to a property via `BindTo`

---

## Attribute Reference

### `DreaminePropertyAttribute`

Marks a field for generated property creation.

```csharp
[DreamineProperty]
private string _name;
```

Optional parameter:

- `propertyName`: explicitly overrides the generated property name

---

### `RelayCommandAttribute`

Marks a method for generated command creation.

```csharp
[RelayCommand]
private void Save()
{
}
```

Optional parameter:

- `commandName`: explicitly overrides the generated command property name

---

### `DreamineCommandAttribute`

Marks a method for target-method invocation / forwarding scenarios.

```csharp
[DreamineCommand("Service.Load", BindTo = "Result")]
partial void Load();
```

Members:

- `TargetMethod`: target method path
- `BindTo`: optional property that receives the return value
- `CommandName`: optional explicit command property name

---

### `DreamineEntryAttribute`

Marks a class as an entry type.

```csharp
[DreamineEntry]
public partial class MainViewModel
{
}
```

Useful for:

- startup discovery
- generator scanning rules
- explicit architectural intent

---

### `DreamineModelAttribute`

Marks a class or field as part of the model layer.

```csharp
[DreamineModel]
private MainModel _model;
```

Optional parameter:

- `propertyName`: explicit generated property name

---

### `DreamineEventAttribute`

Marks a class or field for event-related generation or interpretation.

```csharp
[DreamineEvent]
private MainEvent _event;
```

Optional parameter:

- `propertyName`: explicit generated property name

---

### `DreamineModelPropertyAttribute`

Maps a ViewModel field to a Model property proxy.

```csharp
[DreamineModelProperty("Readme")]
private string _readme;
```

Optional parameter:

- `modelPropertyName`: explicit model property name

---

## Design Notes

This package intentionally keeps the attribute layer **small and dependency-free**.

That means:

- no MVVM runtime logic inside the package
- no command implementation inside the package
- no property notification implementation inside the package
- only metadata and declaration markers

This separation keeps the architecture aligned with SOLID principles:

- **Single Responsibility**: attributes only describe intent
- **Open/Closed**: generators can evolve without changing ViewModel usage
- **Dependency Inversion**: ViewModels depend on abstractions/declarations, not generation internals

---

## Comparison

| Package | Role | Runtime Logic | Code Generation Markers |
|---|---|---:|---:|
| CommunityToolkit.Mvvm | MVVM toolkit | Yes | Yes |
| Prism | MVVM framework | Yes | No |
| Dreamine.MVVM.Attributes | Attribute declarations | No | Yes |

Dreamine.MVVM.Attributes is intentionally focused on the **declaration layer**, not the full runtime framework.

---

## Recommended Package Pairing

This package is most useful when combined with:

```text
Dreamine.MVVM.Core
Dreamine.MVVM.Generators
Dreamine runtime / UI packages
```

By itself, this package mainly defines metadata for higher-level Dreamine tooling.

---

## License

MIT License
