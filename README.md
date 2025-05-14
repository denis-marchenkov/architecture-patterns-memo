# architecture-patterns-memo

<br />

Quick reference for most popular architectural patterns

<br />

## Common concepts

<br />

The general idea of applying architectural patterns is to achieve **maintainable** loosely coupled application with a distinct separation of concerns. 

<br />

And when we speak about maintainable code it might be a good idea to define "maintainability" which is actually already defined in **ISO/IEC 25002** (by the way ISO comes from the greek word 'isos' (equal) and not an acronym): 

<br />

```
MAINTAINABILITY
│
├── Analyzability – How easy to identify what needs fixing or improving
├── Changeability – How easy to make changes (in terms of ease)
├── Modifiability – How easy to modify without causing issues (in terms of risks)
├── Testability – How easy to test modified parts
└── Stability – Resistance to unexpected effects after change
```

As you might have noticed calling something "**maintainable**" already implies that it's **testable, stable and easy to change**.
<br />


While design patterns (factory, decorator etc) allow us to make classes maintainable - architectural patterns (onion, hexagonal etc.) aim for the same goal on solution level. 

<br />

Key principals shared by layered / module architectures are:

<br />

- **Inversion of control** (inner layers define interfaces for outer layers to implement)
- **Separation of concerns** (each layer responsible for its own thing, business logic decoupled from infrastructure)
- **Replacable components** (databases, UIs etc. can be swapped with relatively small changes)
- **Every layer is testable** while core layer can be tested without any mocks

<br />

In layered / module architectures there are a lot of common concepts:

- **Domain** - core business logic and rules (entities, repository intefraces, domain services)
- **Application** - coordinates application activity, orchestrates interactions between domain entities (use cases, DTOs, commands and queries, mediators)
- **Infrastructure** - provides technical capabilities to support other layers (persistence, communication, repository implementation, logging, configuration)
- **Presentation** - handles user interactions through UI / API / CLI (controllers,  API endpoints, views, serializers, validators)

<br />

The above is what might be called core layers they won't necessarily contain all of the listed functionality (or on the contrary - will contain more), but in general all of them will be presented in a layered architecture.

<br />

### Layers memo

| Layer Name           | Type     | Description |
|----------------------|----------|-------------|
| **Domain**           | Core     | Business rules, entities. Does not depend on other layers. |
| **Application**      | Core     | Use cases, application activity, interactions between domain entities. |
| **Infrastructure**   | Core     | Databases, external APIs |
| **Presentation**     | Core     | APIs, views, CLI, etc. |
| **Contracts**        | Optional | Shared interfaces/APIs (e.g. ports). |
| **Shared Kernel**    | Optional | Shared types, constants, DTOs, helpers etc. used across bounded contexts. |
| **Cross-Cutting**    | Optional | Logging, caching, security, telemetry, exception handling, idempotency, messaging. |
| **Messaging**        | Optional | Event publishing, message brokers, sagas, retry logic. |
| **Configuration**    | Optional | Centralized app settings, environment-specific configs, feature flags. |
| **UI**               | Optional | Web UI components (Razor pages, React components, Blazor files, view models). |
| **Tests**            | Optional | Well, tests. Optional... but mandatory. |


