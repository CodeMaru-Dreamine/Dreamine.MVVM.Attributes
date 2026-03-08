<!--!
\file README_KO.md
\brief Dreamine.MVVM.Attributes - Dreamine MVVM 코드 생성을 위한 Attribute 정의 모듈.
\details 패키지 목적, 설치, 아키텍처 역할, 사용 예제, Attribute 설명을 정리합니다.
\author Dreamine
\date 2026-03-08
\version 1.0.4
-->

# Dreamine.MVVM.Attributes

**Dreamine.MVVM.Attributes**는 Dreamine MVVM 생태계에서 사용하는 **경량 Attribute 정의 패키지**입니다.

이 패키지는 MVVM 동작 자체를 직접 구현하지 않습니다.  
대신 Dreamine의 소스 제너레이터 및 런타임 패키지들이 해석할 **선언용 마커(Attribute)** 를 제공합니다.

즉, 반복적인 ViewModel 코드를 줄이기 위한 **선언 계층**이라고 보면 됩니다.

[➡️ English Version](README.md)

---

## 이 라이브러리가 해결하는 문제

MVVM 프로젝트에서는 다음과 같은 반복 패턴이 자주 발생합니다.

- private field → public property 변환
- method → command property 변환
- ViewModel ↔ Model 프록시 매핑
- 엔트리 클래스 / 구조적 역할 마킹
- 특정 Event/Service 메서드로 위임되는 커맨드 선언

이 패키지는 이러한 반복 구조를 **Attribute 기반 선언 방식**으로 통일하여, 상위 Dreamine 도구들이 일관되게 코드를 생성할 수 있도록 돕습니다.

---

## 주요 기능

- 의존성이 거의 없는 **Attribute 전용 패키지**
- Dreamine MVVM **소스 생성 워크플로우**를 위한 설계
- 프로퍼티 생성용 마커 제공
- 커맨드 생성용 마커 제공
- 엔트리 / 모델 / 이벤트 구조 마커 제공
- ViewModel → Model 프록시 속성 매핑 지원
- **netstandard2.0** 대상이라 호환 범위가 넓음

---

## 요구사항

- **Target Framework**: `netstandard2.0`
- 일반적으로 아래 패키지와 함께 사용합니다.
  - Dreamine MVVM Generator 패키지
  - Dreamine MVVM Runtime/Core 패키지
  - WPF 등 .NET 데스크톱 MVVM 프로젝트

---

## 설치

### 옵션 A) NuGet

```bash
dotnet add package Dreamine.MVVM.Attributes
```

### 옵션 B) PackageReference

```xml
<ItemGroup>
  <PackageReference Include="Dreamine.MVVM.Attributes" Version="1.0.4" />
</ItemGroup>
```

---

## 프로젝트 구조

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

## 아키텍처 역할

이 패키지는 Dreamine MVVM 스택에서 **선언 계층** 역할을 담당합니다.

```text
ViewModel Source Code
        │
        ├─ Dreamine.MVVM.Attributes
        │     (마커 / 메타데이터)
        │
        ├─ Dreamine Generator
        │     (코드 생성)
        │
        └─ Dreamine Runtime/Core
              (실행 / MVVM 인프라)
```

즉, Attribute는 **의도(intent)** 를 선언하고, 실제 동작은 다른 Dreamine 패키지가 담당합니다.

---

## 빠른 시작

### 1) 프로퍼티 생성 마커

```csharp
using Dreamine.MVVM.Attributes;

public partial class MainViewModel
{
    [DreamineProperty]
    private string _title;
}
```

의도:

- 필드 기반 선언
- public 프로퍼티 자동 생성
- 속성 변경 알림은 제너레이터 / 런타임이 처리

---

### 2) 커맨드 생성 마커

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

의도:

- 메서드를 커맨드 원본으로 표시
- 커맨드 프로퍼티 자동 생성
- 기본 이름은 `{MethodName}Command`

---

### 3) 엔트리 마커

```csharp
using Dreamine.MVVM.Attributes;

[DreamineEntry]
public partial class MainViewModel
{
}
```

의도:

- 주요 진입 클래스를 표시
- 검색 / 부트스트랩 시나리오에서 활용 가능

---

### 4) Model 프록시 매핑 마커

```csharp
using Dreamine.MVVM.Attributes;

public partial class MainViewModel
{
    [DreamineModelProperty]
    private string _readme;
}
```

의도:

- ViewModel 필드를 Model 프로퍼티 프록시로 연결
- 제너레이터가 `Model.Readme` 또는 지정된 이름으로 매핑

---

### 5) 위임 커맨드 마커

```csharp
using Dreamine.MVVM.Attributes;

public partial class MainViewModel
{
    [DreamineCommand("Event.ReadmeClick", BindTo = "Readme")]
    partial void LoadReadme();
}
```

의도:

- 명시된 대상 메서드 호출 코드 생성
- `Event.*`, `Service.*` 같은 경로 기반 위임
- `BindTo`를 통해 반환값 자동 대입 가능

---

## Attribute 설명

### `DreaminePropertyAttribute`

필드를 생성 프로퍼티 대상으로 표시합니다.

```csharp
[DreamineProperty]
private string _name;
```

옵션:

- `propertyName`: 생성될 프로퍼티 이름 강제 지정

---

### `RelayCommandAttribute`

메서드를 생성 커맨드 대상으로 표시합니다.

```csharp
[RelayCommand]
private void Save()
{
}
```

옵션:

- `commandName`: 생성될 커맨드 프로퍼티 이름 강제 지정

---

### `DreamineCommandAttribute`

특정 대상 메서드를 호출하는 위임/포워딩 시나리오를 선언합니다.

```csharp
[DreamineCommand("Service.Load", BindTo = "Result")]
partial void Load();
```

주요 멤버:

- `TargetMethod`: 호출 대상 메서드 경로
- `BindTo`: 반환값을 대입할 프로퍼티명
- `CommandName`: 강제 커맨드 이름

---

### `DreamineEntryAttribute`

클래스를 엔트리 타입으로 표시합니다.

```csharp
[DreamineEntry]
public partial class MainViewModel
{
}
```

활용 예:

- 시작점 검색
- 제너레이터 스캔 규칙
- 아키텍처 의도 표현

---

### `DreamineModelAttribute`

클래스 또는 필드를 모델 계층 대상으로 표시합니다.

```csharp
[DreamineModel]
private MainModel _model;
```

옵션:

- `propertyName`: 생성될 프로퍼티 이름 지정

---

### `DreamineEventAttribute`

클래스 또는 필드를 이벤트 관련 대상으로 표시합니다.

```csharp
[DreamineEvent]
private MainEvent _event;
```

옵션:

- `propertyName`: 생성될 프로퍼티 이름 지정

---

### `DreamineModelPropertyAttribute`

ViewModel 필드를 Model 프로퍼티 프록시로 매핑합니다.

```csharp
[DreamineModelProperty("Readme")]
private string _readme;
```

옵션:

- `modelPropertyName`: Model의 실제 프로퍼티 이름 지정

---

## 설계 노트

이 패키지는 의도적으로 **작고 가벼운 선언 계층**만 유지합니다.

즉, 이 안에는 없습니다.

- MVVM 런타임 로직
- ICommand 구현체
- PropertyChanged 구현
- 실행 코드

오직 **메타데이터와 선언 마커**만 존재합니다.

이 구조는 SOLID 관점에서도 장점이 있습니다.

- **SRP**: Attribute는 의도만 표현
- **OCP**: 제너레이터 확장 시 ViewModel 사용 방식은 유지
- **DIP**: ViewModel이 생성 내부 구현에 직접 의존하지 않음

---

## 비교

| 패키지 | 역할 | 런타임 로직 | 코드 생성 마커 |
|---|---|---:|---:|
| CommunityToolkit.Mvvm | MVVM 툴킷 | 예 | 예 |
| Prism | MVVM 프레임워크 | 예 | 아니오 |
| Dreamine.MVVM.Attributes | Attribute 선언 | 아니오 | 예 |

Dreamine.MVVM.Attributes는 전체 프레임워크가 아니라 **선언 전용 모듈**이라는 점이 핵심입니다.

---

## 함께 쓰면 좋은 패키지

이 패키지는 보통 아래와 함께 사용할 때 가장 유용합니다.

```text
Dreamine.MVVM.Core
Dreamine.MVVM.Generators
Dreamine runtime / UI packages
```

단독으로도 참조는 가능하지만, 주된 목적은 상위 Dreamine 툴링을 위한 메타데이터 제공입니다.

---

## License

MIT License
