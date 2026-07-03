# Commit Message Guidelines

This repository follows Conventional Commits v1.0.0 for clear, consistent, and automatable commit history.

Based on the official spec: https://www.conventionalcommits.org/en/v1.0.0/

## Purpose

- Keep commit history readable and discoverable.
- Support changelog generation, automation, and code review clarity.
- Encourage small, focused, and well-described changes.

## Commit Message Format

Use the format:

```text
<type>(<scope>): <short summary>

<body>

<footer>
```

### Required parts

- `type`: one of the accepted types below.
- `scope`: optional component or area of the project.
- `short summary`: brief description in imperative mood, max 50 characters when possible.

### Optional parts

- `body`: explain the reasoning, what changed, and any important details.
- `footer`: reference issues, breaking changes, or other metadata.

## Accepted Types

- `feat`: A new feature
- `fix`: A bug fix
- `docs`: Documentation only changes
- `style`: Formatting, missing semicolons, whitespace, no code change
- `refactor`: Code change that neither fixes a bug nor adds a feature
- `perf`: A code change that improves performance
- `test`: Adding missing tests or correcting existing tests
- `build`: Changes that affect the build system or external dependencies
- `ci`: Continuous integration and workflow changes
- `chore`: Other changes that do not modify src or test files

## Examples

```text
docs: add software development lifecycle document

feat(spec): add commit message guidelines

fix(ci): correct pipeline workflow trigger
```

## Best Practices

- Keep each commit focused on a single logical change.
- Avoid mixing unrelated changes in one commit.
- Use the imperative mood: "add", "fix", "update", not "added" or "fixes".
- Include a body when the change is not obvious from the summary.
- Reference issues or pull requests in the footer if applicable.

## Breaking Changes

If a commit introduces a breaking change, include a footer entry:

```text
BREAKING CHANGE: description of the change and migration steps
```

## Scope Guidance

- Use `(<scope>)` when the change affects a specific area, module, or feature.
- Keep scope lowercase and concise, for example `docs`, `ci`, `build`, `spec`, `readme`.

## Repository Practice

- Use `docs:` for documentation and specification updates.
- Use `spec:` for specification-related files or process improvements.
- Use `chore:` for housekeeping changes that do not affect production code.
