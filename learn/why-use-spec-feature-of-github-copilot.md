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

## Practical Use

Use `spec` content to explain:

- commit message format and allowed commit types,
- repository conventions for docs, tests, and code changes,
- naming patterns and review expectations,
- workflow practices such as branch naming and PR descriptions.

## Why It Matters

A well-defined spec helps the team avoid repeated corrections and reduces friction. It also makes Copilot more useful by giving it explicit guidance instead of relying only on implicit patterns from existing code.
