# Measure productivity gains
Understanding the productivity gains provided by GitHub Copilot is essential to maximizing its benefits. The REST API for GitHub Copilot usage metrics and GitHub Copilot Developer Survey offers a powerful way to measure and analyze ' GitHub Copilot influences your development workflow. This section introduces methods to evaluate GitHub Copilot's impact using these tools and related metrics.

## Use the REST API endpoints for GitHub Copilot usage metrics
GitHub provides a REST API to access GitHub Copilot usage metrics for enterprise members, teams, and organization members. These metrics offer insights into daily usage of GitHub Copilot, including completions, chat interactions, and user engagement across different editors and languages.

### Get a summary of GitHub Copilot usage for enterprise members
Endpoint: _GET /enterprises/{enterprise}/GitHub Copilot/usage_

This endpoint provides a daily breakdown of aggregated usage metrics for GitHub Copilot completions and GitHub Copilot Chat across all users in an enterprise. It includes details on suggestions, acceptances, and active users, further broken down by editor and language.

### Get a summary of GitHub Copilot usage for an enterprise team
Endpoint: GET /enterprises/{enterprise}/team/{team_slug}/GitHub Copilot/usage

This endpoint provides a daily breakdown of aggregated usage metrics for GitHub Copilot completions and GitHub Copilot Chat within a specific enterprise team.

### Get a summary of GitHub Copilot usage for organization members
Endpoint: GET /orgs/{org}/GitHub Copilot/usage

This endpoint provides a daily breakdown of aggregated usage metrics for GitHub Copilot completions and GitHub Copilot Chat across an organization.

## Implementing a measurement framework
To systematically assess GitHub Copilot's impact, consider the following framework, using the GitHub Copilot usage metric API at each stage:

- Evaluation: During the initial phase of adopting GitHub Copilot, focus on leading indicators such as developer satisfaction and task completion rates. Use the API to collect metrics like Average Daily Active Users, Total Acceptance Rate, and Lines of Code Accepted.

- Adoption: As GitHub Copilot becomes more integrated into your team's workflow, continue to monitor productivity metrics and enablement indicators. The API can provide insights into user engagement and identify areas where further training may be needed.

- Optimization: Once GitHub Copilot is fully adopted, use the REST API for GitHub Copilot usage metrics to fine-tune its impact on broader organizational goals, such as reducing time-to-market or improving code quality across the team.

- Sustained efficiency: Continuously evaluate GitHub Copilot's effectiveness as your organization evolves. The API allows for ongoing monitoring and adjustment to ensure long-term productivity gains.

## Use the GitHub Copilot developer survey
The GitHub Copilot Developer Survey is a valuable tool designed to gather insights from your teams, helping you understand ' GitHub Copilot is being used, its benefits, and any challenges developers face. This survey is divided into two formats: short-form and long-form, each serving different purposes throughout the GitHub Copilot evaluation and adoption stages.

1. Survey cadence and timing

When deploying the GitHub Copilot Developer Survey, it's important to establish a regular cadence to avoid survey fatigue while still gathering meaningful data.

- Short-form survey: Can be conducted every two weeks if frequent feedback is needed, especially when coupled with other feedback channels like online or in-person discussions.
- Long-form survey: Recommended to be conducted no more than once every four weeks, particularly at the end of the evaluation and adoption stages, to capture comprehensive feedback.

2. Structuring the survey

The survey questions should be tailored to fit your organization's specific needs, ensuring that the data collected is relevant and actionable. Here's ' to structure both the short-form and long-form surveys:

- Short-form survey: Focuses on immediate feedback, capturing developers' overall satisfaction with GitHub Copilot, specific challenges faced, and time saved or wasted.

Example questions:
```
"' would you feel if you could no longer use GitHub Copilot?"
"When using GitHub Copilot, I enjoy coding more / write better quality code / complete tasks faster."
"What challenges have you encountered in using GitHub Copilot since your last survey?"
```

- Long-form survey: Offers a deeper analysis of GitHub Copilot's impact, capturing detailed insights into its usage and benefits, and ' it affects team dynamics.

Example questions:
```
"I use GitHub Copilot to code in a familiar language / explore a new language / write repetitive code."
"When using GitHub Copilot, my team provides better code reviews / merges code to production faster."
"What challenges have you encountered in using GitHub Copilot since your last survey?"
```

3. Analyzing survey results

Once the surveys are completed, it's important to analyze the results systematically:

- Privacy considerations: Ensure that survey responses are anonymized and cannot be traced back to individual developers, meeting privacy obligations.
- Data tracking: Collate the survey responses into existing Business Intelligence (BI) tools or spreadsheets for ease of analysis. Over time, track the results to identify trends and make informed decisions about GitHub Copilot's implementation.

4. Continuous improvement

Use the insights gathered from the surveys to make informed decisions about GitHub Copilot's deployment in your organization. Focus on addressing the challenges identified, leveraging the benefits reported by developers, and adjusting the tool's use to maximize productivity.

The GitHub Copilot Developer Survey is a critical component in understanding and enhancing the use of GitHub Copilot within your teams.

By leveraging the REST API and survey for GitHub Copilot usage metrics, you can move beyond anecdotal evidence and gain concrete insights into how GitHub Copilot influences your coding process. This data-driven approach allows for informed decision-making and continuous improvement on GitHub Copilot's role in the development workflow and helps identify areas where its use can be optimized for maximum benefit.