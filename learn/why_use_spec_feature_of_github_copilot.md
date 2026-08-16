# Why Use the `spec` Feature of GitHub Copilot

GitHub Copilot's `spec` feature helps teams capture agreed-upon conventions, design decisions, and process rules in a machine-readable way. It makes AI suggestions more aligned with project standards and reduces the time spent correcting style, structure, or workflow-related guidance.

## Benefits

- Improves consistency across commits, PRs, and documentation.
- Helps Copilot generate suggestions that respect the repository's processes.
- Makes onboarding simpler by documenting expected practices in a central place.
- Supports automation and review tools when the project uses structured conventions.

## How it Helps

When a project defines a `spec` directory or spec files, Copilot can use those guidelines as context. That means:

- commit message recommendations can follow the project's chosen convention,
- file creation and formatting suggestions can match documented standards,
- terminology and scope conventions stay consistent across contributions.

## Spec-Driven Development and GitHub Spec Kit

This matches the goals described in the Microsoft article about GitHub Spec Kit. Spec-Driven Development (SDD) is about making technical decisions explicit, reviewable, and evolvable.

- Specs become the shared context for the team, not just the code.
- This reduces the risk of different contributors making conflicting assumptions.
- It enables AI agents to build from a clear, agreed-upon plan instead of guessing from implementation alone.

GitHub Spec Kit emphasizes the same ideas:

- create a spec first,
- then turn it into a technical plan,
- then break it into tasks.

That sequence helps preserve the "why" behind decisions and makes future changes easier.

> Note: GitHub Spec Kit uses a lightweight project workflow around `spec`, `plan`, and `tasks`. In this repository, the same principles apply using `spec/` files and documentation, even if the full `.specify/` scaffolding is not present.

## Practical Use

Use `spec` content to explain:

- commit message format and allowed commit types,
- repository conventions for docs, tests, and code changes,
- naming patterns and review expectations,
- workflow practices such as branch naming and PR descriptions.

## Spec Kit Concepts to Follow

- Keep specs lightweight and actionable. They are not meant to be exhaustive or bureaucratic.
- Treat specs as living documents that evolve with the project.
- Include high-level direction, constraints, and non-negotiable principles when relevant.
- Use spec files to give AI agents better context, especially when a project may have multiple implementation alternatives.

## Why It Matters

A well-defined spec helps the team avoid repeated corrections and reduces friction. It also makes Copilot more useful by giving it explicit guidance instead of relying only on implicit patterns from existing code.

## Related Practices

- Add a `spec/README.md` or similar overview file so team members know where the project spec lives.
- Use `spec`-driven commit messages when updating conventions or requirements.
- Update the spec before making big implementation changes, so the design stays testable and reviewable.
