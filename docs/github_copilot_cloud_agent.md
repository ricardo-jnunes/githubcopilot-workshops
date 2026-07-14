# What is GitHub Copilot Cloud Agent , who can use it and where it's available.

GitHub Copilot Cloud Agent is an autonomous development assistant that runs inside GitHub itself. Rather than pairing with you only in your IDE, the agent acts like a background teammate. You give it a clearly scoped task—such as a bug fix, an incremental feature, or documentation update—and it creates a branch, explores the codebase, generates an implementation plan, and drafts code while keeping you in control of when and whether to open a pull request.

## Availability and plans
- Plans: Available on Copilot Pro, Copilot Pro+, Copilot Business, Copilot Enterprise.
- Repositories: Works in all GitHub-hosted repositories except those owned by managed user accounts or where the agent is explicitly disabled.

## What the Copilot Cloud Agent does
Copilot Cloud Agent can take on a wide range of development tasks:

- Fix bugs and regressions.
- Implement incremental new features.
- Improve test coverage or generate missing tests.
- Update or create documentation.
- Address technical debt and "nice-to-have" backlog items.

### You can delegate work to the agent in two primary ways:

- Assign an issue to Copilot - on GitHub.com, GitHub Mobile, or via API/CLI.
- Ask Copilot to make code changes - from the Agents panel on GitHub, Copilot 

Chat, your IDE or other agentic tool with MCP support, or Raycast on macOS.
When the agent finishes, it requests your review. You can mention _@copilot_ in a pull-request comment to ask it to iterate on its work.

With Copilot Cloud Agent :

All work happens as commits on GitHub.
-  The agent automates branch creation, commit messages, and code drafting, while letting you decide if and when to open a PR.
-  Work is visible in session logs and PR history for traceability.
-  You steer via PR review comments rather than synchronous local sessions.

This creates transparency and collaboration opportunities-your teammates can see each step and jump in as needed.

## Cloud agent vs. "Agent Mode" in IDEs
It's important to distinguish the GitHub Copilot Cloud Agent (covered in this module) from the agent mode feature in Visual Studio and Visual Studio Code:

- Cloud agent: Runs autonomously in a GitHub Actions-powered environment to complete development tasks you assign through issues or Copilot Chat.
- Agent mode (Copilot Edits): Performs autonomous local edits directly in your IDE session.

# Enabling the Copilot Cloud Agent
Before assigning tasks to Copilot, ensure the agent is enabled:

- Organization-owned repositories: Availability is managed by organization or enterprise administrators.
- Personal repositories: Configure availability in your account settings.
Usage Costs: GitHub Actions + PRUs

Copilot Cloud Agent uses two main resources:

- GitHub Actions minutes for the ephemeral build/test environment where the agent works.
- Copilot Premium Requests (PRUs/Premium Request Unit) to power advanced model reasoning.

# Security, risks, and limitations of the Copilot Cloud Agent

The GitHub Copilot Cloud Agent is designed from the ground up with security and governance in mind. While it unlocks new ways of delegating work to an autonomous agent, it operates inside your organization's existing guardrails and adds its own protections. 

Security is foundational to the Copilot Cloud Agent . It respects your existing controls and applies its own guardrails to keep your workflows safe:

- Subject to governance - Organization and enterprise settings govern availability; all your security policies continue to apply to the agent.
- Restricted environment - The agent runs inside a sandbox on GitHub Actions with firewalled internet access and read-only access to your repository.
- Branch limits - It can only create and push to branches beginning with copilot/, and all branch protections and required checks still apply.
- Permission-aware - The agent only responds to users with write permission. Comments from others are ignored.
- Outside-collaborator rules - Draft PRs from the agent require approval by a user with write permission before Actions run. The person who requested the PR can't approve it.
- Compliance and attribution - All commits are coauthored with the developer who assigned the task or requested the PR, so attribution is clear. Existing "required approvals" rules remain intact.

## Risks and mitigations
Although the Copilot Cloud Agent is built with security in mind, there are still risks you should plan for. GitHub applies mitigations to reduce them:

- Risk: Agent pushes code
    - Mitigations: Only users with write access can trigger agent work. Pushes are restricted to copilot/ branches (not main/master). The agent's credentials allow simple push only (no direct git push). GitHub Actions workflows won't run until a write-permission user clicks "Approve and run workflows". The requestor can't approve the agent's PR, maintaining required approvals.
- Risk: Access to sensitive information
    - Mitigation: The agent's internet access is firewall-restricted by default; you can customize or disable the firewall per policy.
- Risk: Prompt injection
    - Mitigation: Hidden characters (such as HTML comments) are filtered before passing user input to the agent. This reduces the chance of hidden harmful instructions in comments or issues.

## Known limitations
**Workflow limitations**

- Can only make changes in the same repository as the assigned issue or PR.
- Context scope is limited to the assigned repository by default (can be broadened via MCP).
- Opens exactly one pull request per task.
- Can't modify an existing PR it didn't create (add it as a reviewer if you need feedback instead by leveraging GitHub Copilot code review).

**Compatibility limitations**

- Doesn't sign commits. If you require signed commits, you must rewrite the commit history before merging.
- Requires GitHub-hosted Ubuntu x64 runners. Self-hosted runners are not supported.
- Not available for personal repositories owned by managed user accounts (runners unavailable).
- Doesn't honor content exclusions; the agent can see and update excluded files.
- The "Suggestions matching public code" policy isn't enforced by the agent; references may not be provided.
- Works only with GitHub-hosted repositories.
- You can't change the AI model used by the agent; it's selected by GitHub.

# Assigning, tracking, and troubleshooting Copilot Cloud Agent tasks
The GitHub Copilot Cloud Agent acts as an autonomous teammate that works directly inside GitHub. Once it is enabled, you can assign it a task, watch its progress in real time, and guide its work by leaving comments on its pull requests. 

## Assigning issues to Copilot
When you assign an issue to Copilot, the agent acknowledges it by adding an 👀 reaction to the issue. It then creates a dedicated copilot/ branch, opens a draft pull request linked to the issue, and begins an agent session inside a GitHub Actions-powered environment. As it works, Copilot pushes commits to the branch and updates the pull request body with status messages. Once the task is complete, Copilot posts a "Copilot finished work" event and requests your review.

On GitHub.com, you assign an issue to Copilot just like you would assign it to another user. Navigate to the repository's Issues tab, open the issue you want to delegate, and in the right sidebar under Assignees, select Copilot. Copilot receives the issue title, description, and any existing comments at the time of assignment. Later comments on the issue are not seen by the agent, so add new information as comments directly on the agent's pull request.

![assign image](https://learn.microsoft.com/en-us/training/github/github-copilot-code-agent/media/issue-assignees-copilot.png)

You can also assign issues to Copilot from the list of issues on a repository's Issues page, from GitHub Projects, or by using GitHub Mobile. For command-line workflows, you can use the GitHub CLI (gh issue edit) to add Copilot as an assignee.

## Assigning via the API
You can assign issues to Copilot programmatically through the GraphQL API. First, check that the coding agent is available by querying suggestedActors for the repository and verifying that copilot-swe-agent appears as a suggested actor. Next, fetch the repository ID. To create and assign a new issue, use the createIssue mutation, passing the repository ID and Copilot's bot ID. To assign an existing issue, fetch the issue ID and then use the replaceActorsForAssignable mutation to add Copilot as the assignee. This approach is useful for integrating Copilot into automated workflows.

### Availability check

```graphql
query {
  repository(owner: "octo-org", name: "octo-repo") {
    suggestedActors(capabilities: [CAN_BE_ASSIGNED], first: 100) {
      nodes { login __typename ... on Bot { id } ... on User { id } }
    }
  }
}
```

### Get repository ID

```graphql
query {
  repository(owner: "octo-org", name: "octo-repo") { id }
}
```

### Create and assign a new issue

```graphql
mutation {
  createIssue(
    input: {
      repositoryId: "REPOSITORY_ID",
      title: "Implement comprehensive unit tests",
      body: "DETAILS",
      assigneeIds: ["BOT_ID"]
    }
  ) {
    issue { id title assignees(first: 10) { nodes { login } } }
  }
}
```
### Assign an existing issue

```graphql
query {
  repository(owner: "monalisa", name: "octocat") {
    issue(number: 9000) { id title }
  }
}

mutation {
  replaceActorsForAssignable(
    input: { assignableId: "ISSUE_ID", actorIds: ["BOT_ID"] }
  ) {
    assignable {
      ... on Issue {
        id title
        assignees(first: 10) { nodes { login } }
      }
    }
  }
}
```

## Tracking Copilot's progress
After you assign an issue to GitHub Copilot, the agent provides visible signals so you can follow its work from start to finish.

- Immediate confirmation. Shortly after you assign an issue, Copilot adds an 👀 reaction to the issue.
- Draft pull request creation. Within a few seconds, Copilot opens a draft pull request linked to the original issue. A new event appears in the issue's timeline showing the pull request.
- Active agent session. Copilot starts an agent session to work on your issue. You'll see a "Copilot started work" event in the pull request timeline. As it runs, Copilot updates the pull request body with regular status messages and pushes commits to the dedicated branch.
- Live session logs. All your sessions-past and present-are visible from the Agents page. Click View session on the pull request to open the live session log viewer and watch Copilot's actions in real time. If you need to stop Copilot, click Stop session in the viewer.
- Completion and review. When Copilot finishes its work, the agent session ends automatically. A "Copilot finished work" event appears in the pull request timeline, and Copilot requests a review from you, triggering a notification.

## Iterating with Copilot
You guide Copilot's work the same way you would guide a human contributor-through comments and reviews. Mention @copilot in a pull request comment to request changes. Only comments from users with write permission to the repository are processed. Copilot posts an 👀 reaction to your comment to confirm that it has received the request, then adds "Copilot started work" to the pull request timeline as it resumes. This allows you to iterate on Copilot's work without leaving your normal review workflow.

## Approvals and workflows
Pull requests created by Copilot are always in draft state. They require human approval before merge, and GitHub Actions workflows triggered by the agent do not run automatically. To run workflows on a Copilot pull request, click Approve and run workflows in the merge box. The developer who asked Copilot to create the pull request cannot approve it, which preserves your repository's "required reviews" rules and ensures an independent review before merge.

## Troubleshooting Copilot Cloud Agent
- Copilot not in "Assignees" list
    - Ensure you're on an eligible plan (Pro, Pro+, Business, Enterprise). Confirm the agent isn't disabled at the org/repo level. Verify on your features page: _github.com/settings/copilot/features_.
- Enterprise Managed User (EMU) personal repositories
    - Agent not available; use organization-owned repositories (requires GitHub-hosted runners).
- "Cannot create a pull request" from Chat
    - Ensure the agent is available. In IDEs, mention @github in your prompt (not required on GitHub.com).
- Assigned an issue but nothing happened
    - Refresh; look for the 👀 reaction, then a draft PR.
- PR created but no progress
    - Check PR timeline for "Copilot started work"; open View session logs.
- Agent not responding to PR comment
    - Confirm you have write access and mentioned @copilot on the agent's PR.
- Appears stuck
    - It may recover; sessions time out after one hour. Retry by unassigning/reassigning the issue or reposting the comment.
- Actions aren't running
    - Click Approve and run workflows in the merge box.
- Pushes don't pass CI
    - Provide clear repo-level guidance via .github/copilot-instructions.md so the agent can self-validate with tests/linters.
- Firewall warnings
    - The Internet is restricted by default; warnings list the blocked address and command. Adjust per Customizing or disabling the firewall for GitHub Copilot Cloud Agent.
- Images not picked up
    - Max image size is 3.00 MiB; larger images are removed.

# Customizing, extending, and validating the Copilot Cloud Agent
GitHub Copilot Cloud Agent runs inside a secure, ephemeral GitHub Actions environment. With a few configuration steps you can preseed this environment to improve reliability and speed, extend the agent's capabilities with external tools through the Model Context Protocol (MCP), and apply best practices to test and validate the agent's output before merging.

## Preseeding the development environment
Preinstall tools & dependencies with copilot-setup-steps.yml

Create _.github/workflows/copilot-setup-steps.yml_ on your repository's default branch. The workflow must define a single job named copilot-setup-steps. Include any steps needed to install dependencies or set up tools.

```typescript
name: "Copilot Setup Steps"

on:
  workflow_dispatch:
  push:
    paths:
      - .github/workflows/copilot-setup-steps.yml
  pull_request:
    paths:
      - .github/workflows/copilot-setup-steps.yml

jobs:
  copilot-setup-steps:
    runs-on: ubuntu-latest
    permissions:
      contents: read
    steps:
      - name: Checkout code
        uses: actions/checkout@v5
      - name: Set up Node.js
        uses: actions/setup-node@v4
        with:
          node-version: "20"
          cache: "npm"
      - name: Install JavaScript dependencies
        run: npm ci
```

Allowed configuration keys for the copilot-setup-steps job: _steps, permissions, runs-on, container, services, snapshot, timeout-minutes (≤ 59)_. Any _actions/checkout_ fetch-depth is overridden to allow safe rollback. The setup workflow runs standalone (so you can validate it) and then automatically before the agent starts.

### Larger GitHub-hosted runners

- Add larger runners first
- In _copilot-setup-steps.yml_, set runs-on to the label/group (for example, ubuntu-4-core).
- Only Ubuntu x64 runners are supported; self-hosted runners aren't supported.

### Git LFS

If you use Git Large File Storage, enable it in setup steps:

```yaml
jobs:
  copilot-setup-steps:
    runs-on: ubuntu-latest
    permissions:
      contents: read
    steps:
      - uses: actions/checkout@v5
        with:
          lfs: true
```

### Firewall customization

Default internet access is limited to reduce exfiltration risk. You can customize or disable the firewall per organizational policy if needed.

## Extend with the Model Context Protocol (MCP)
MCP is an open standard for connecting LLMs to tools and data. The agent can use tools provided by local or remote MCP servers to expand its capabilities.

Note: Copilot Cloud Agent supports MCP tools only (not resources or prompts). Remote MCP servers that require OAuth aren't supported.

### Default MCP servers

- GitHub MCP Server: Access issues, PRs, and GitHub data with a read-only token scoped to the current repo by default (you can customize the token).
- Playwright MCP Server: Read, interact with, and take screenshots of web pages accessible inside the agent's environment (localhost/127.0.0.1).

#### Repository configuration

Admins can declare MCP servers via a JSON configuration in the repo. Once configured, the agent autonomously uses the available tools-no per-use approval prompts. See Extending GitHub Copilot Cloud Agent with MCP.

Best practices

- Review third-party MCP servers for performance and output quality implications.
- Prefer read tools; if write tools exist, allow only what's necessary.
- Carefully validate the MCP configuration before saving.

## Testing & validating agent output
You remain accountable for quality and security:

- Run CI (tests, linters, scanning) on every agent PR; these checks won't run until you click Approve and run workflows.
- Manually inspect high-impact or sensitive areas.
- Ask the agent to generate tests (e.g., "Add Jest unit tests for all functions in src/utils/ following repo style") - multi-file test generation consumes PRUs.
- Enforce rulesets so agent PRs must pass tests + scanning + linting before merge.
- Label agent PRs (e.g., agent-refactor, agent-tests) to monitor, triage, and revert if needed.
- Iterate instructions in .github/copilot-instructions.md when you see repeated mistakes.
- Revert quickly if needed and request new changes from the agent.

### Using PRUs intentionally for validation

Leverage PRUs for deeper validation tasks such as test coverage expansion, audits across directories, or risky area scans. Lightweight checks consume fewer PRUs, so apply them intentionally to maximize value.

# Responsible use of GitHub Copilot Cloud Agent on GitHub.com

About Copilot Cloud Agent on GitHub.com
Copilot Cloud Agent is an autonomous and asynchronous software development agent integrated into GitHub. The agent can pick up a task from an issue or from Copilot Chat, create a branch, explore the codebase, generate an implementation plan, and draft code—letting you decide if and when to open a pull request.

Copilot Cloud Agent can generate tailored changes based on your description and configurations, including tasks like bug fixes, implementing incremental new features, prototyping, documentation, and codebase maintenance. If you decide to create a pull request, the agent can then iterate with you based on your feedback and reviews.

While working on your task, the agent has access to its own ephemeral development environment where it can make changes to your code, execute automated tests, and run linters. The agent has been evaluated across a variety of programming languages, with English as the primary supported language.

## How the agent works (end-to-end)

- Prompt processing
    - The task provided to Copilot through an issue, pull request comment or Copilot Chat message is combined with other relevant, contextual information to form a prompt. Inputs can take the form of plain natural language, code snippets, or images.
- Language model analysis
    - The prompt is then passed through a large language model, which analyzes the input to help the agent reason on the task and leverage necessary tools.
- Response generation
    - The language model generates a response based on its analysis of the prompt. This response can take the form of natural language suggestions and code suggestions.
- Output formatting
    - Once the agent completes its first run, it will update the pull request description with the changes it made. The agent may include supplemental information about resources it couldn't access and provide suggestions on the steps to resolve.
    - You may provide feedback to the agent by commenting within the pull request or explicitly mentioning the agent (@copilot). The agent will then resubmit that feedback to the language model for further analysis. Once the agent completes changes based on feedback, it will respond to your comment with updated changes.

Copilot is intended to provide you with the most relevant solution for task resolution. However, it may not always provide the answer you are looking for. You are responsible for reviewing and validating responses generated by Copilot to ensure they are accurate and appropriate. Additionally, as part of our product development process, GitHub undertakes red teaming (testing) to understand and improve the safety of the agent.

## Use cases for Copilot Cloud Agent
- Codebase maintenance: Security fixes, dependency upgrades, and targeted refactoring.
- Documentation: Updating and creating new documentation.
- Feature development: Implementing incremental feature requests.
- Improving test coverage: Developing additional test suites for quality management.
- Prototyping new projects: Green fielding new concepts.

## Improving performance for Copilot Cloud Agent
To enhance performance and address limitations, use these measures:

Ensure your tasks are well-scoped by providing:

- A clear description of the problem to be solved or the work required.
- Complete acceptance criteria on what a good solution looks like (for example, should there be unit tests?).
- Hints or pointers on what files need to be changed.

### Customize your experience with additional context

Copilot Cloud Agent leverages your prompt, comments, and the repository's code as context when generating suggested changes. Improve results by adding custom Copilot instructions so the agent understands how to build, test, and validate its changes.

Other helpful customizations:

- Customizing the development environment for GitHub Copilot Cloud Agent
- Customizing or disabling the firewall for GitHub Copilot Cloud Agent
- Extending GitHub Copilot Cloud Agent with the Model Context Protocol (MCP)

### Use Copilot Cloud Agent as a tool, not a replacement

Always review and test the content generated by the agent to ensure it meets your requirements and is free of errors or security concerns prior to merging.

### Use secure coding and code review practices

Although Copilot Cloud Agent can generate syntactically correct code, it may not always be secure. Continue to follow best practices for secure coding (avoid hard-coded secrets, prevent injection vulnerabilities) and apply rigorous testing, IP scanning, and vulnerability checks.

### Provide feedback

If you encounter any issues or limitations, use the thumbs-down icon below an agent response or share feedback in the community discussion forum.

### Stay up to date

Copilot Cloud Agent is evolving. Monitor new security risks and best practices as they emerge.

## Security measures for Copilot Cloud Agent
### Avoiding privilege escalation

- Copilot Cloud Agent will only respond to interactions from users with write access.
- Actions workflows triggered by agent PRs require approval from a user with write access before they run.
- Hidden characters (not rendered on GitHub.com) are filtered to reduce prompt-injection risks.

### Constraining Copilot's permissions

- The agent only accesses the repository where it is scoped to; it cannot access other repositories.
- Pushes are limited to branches with names beginning with copilot/ (not your default branch).
- The agent does not have access to org/repo Actions secrets or variables at runtime. Only secrets/variables added to the copilot environment are passed to the agent.

#### Preventing data exfiltration

A firewall is enabled by default to prevent accidental or malicious exfiltration of code or sensitive data. See Customizing or disabling the firewall for GitHub Copilot Cloud Agent .

## Limitations of Copilot Cloud Agent
Depending on your codebase and inputs, performance can vary. Keep these constraints in mind:

- Limited scope & quality: The LLM may not handle certain code structures or obscure languages; quality varies by language coverage.
- Potential biases: Training data and retrieved context may include biases; the agent may lean toward certain languages or styles.
- Security risks: Generated code is based on repository context and could expose sensitive info if not reviewed; thorough review is required.
- Inaccurate code: Code may appear correct but be semantically/syntactically wrong or misaligned with intent. Validate fit, patterns, and style.
- Public code: The agent may produce matches/near-matches to public code even if "Block" is set; references may not be provided.
- Legal/regulatory: Ensure compliance with applicable obligations; avoid prohibited uses under terms of service and codes of conduct.
