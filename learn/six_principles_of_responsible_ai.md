# GitHub's six principles of responsible AI

* Fairness: AI systems should treat all people fairly.
* Reliability and safety: AI systems should perform reliably and safely.
* Privacy and security: AI systems should be secure and respect privacy.
* Inclusiveness: AI systems should empower everyone and engage people.
* Transparency: AI systems should be understandable.
* Accountability: People should be accountable for AI systems.


## Risks using AI
- Hallucination: Looks correct, but is wrong logic.
- Bias: Repeat Stereotypes or regional patterns.
- Security flaws: e.g. hardcoded secrets.
- Legal violations: e.g. GPL code in MIT License.
- Overreliance: Devs stops thinking critically.

## GitHub Copilot Model Limitations
- **Context awareness**: Limited understanding of your full codebase and business logic
- **Version-specific code**: Training data has a cutoff date; may not include latest library versions
- **Complex algorithms**: Struggles with novel or highly specialized problem domains
- **Documentation accuracy**: May generate plausible-looking but incorrect API usage
- **Security patterns**: Doesn't guarantee secure code; always review for vulnerabilities
- **Performance optimization**: Limited understanding of performance implications

## Always validate the output / Checklist
- Functionality: Does it work? Is this code correct for my context?
- Security: Is it safe? Does it follow secure practices? Is the origin questionable? Is ther any hardedcode credential?
- Relevance: Does it match intent? Does it align with team conventions?

## Operating with AI Responsability
- Use Copilot with code linters, SAST Tools (e.g. SonarQube) and license scanning tools.
- Define usage policies
- Educate people about hallucination, bias and privacy risks
    - Encourage learning and code review practices.

## Practical Prompt Engineering Tips
- **Be specific and detailed**: Provide context about your project, language, and requirements
- **Request sources**: Ask Copilot to provide references or explain its reasoning to catch hallucinations
- **Use step-by-step prompts**: Break complex tasks into smaller, sequential steps
- **Specify constraints**: Include performance, security, and style requirements in prompts
- **Request explanations**: Ask "why" to verify correctness and understand the logic
- **Iterative refinement**: Don't accept the first suggestion; ask follow-up questions



## Code Review Process with AI
1. **Verify functionality**: Test the code thoroughly; don't rely on AI's confidence
2. **Security audit**: Check for hardcoded secrets, SQL injection, authentication issues
3. **License compliance**: Verify generated code doesn't violate license requirements
4. **Team standards**: Ensure code follows your team's conventions and style guides
5. **Performance impact**: Assess algorithmic efficiency and resource usage
6. **Documentation quality**: Verify comments and docstrings are accurate and complete

## Compliance Considerations
- **Data privacy**: Be cautious with sensitive data in prompts; they may be retained
- **GDPR/CCPA**: Ensure AI usage complies with data protection regulations
- **Industry standards**: Verify Copilot output meets compliance requirements (HIPAA, PCI-DSS, etc.)
- **Audit trails**: Document AI-assisted code for compliance auditing
- **Code ownership**: Clarify intellectual property policies around AI-generated code

## Team Guidelines Template
- **When to use Copilot**: Best for scaffolding, boilerplate, and routine coding patterns
- **When NOT to use**: Security-critical code, business logic, regulatory-sensitive features
- **Code review requirements**: All AI-generated code requires peer review before merge
- **Documentation**: Clearly mark AI-assisted sections in code comments
- **Training**: Regular workshops on responsible AI usage and Copilot capabilities
- **Feedback loop**: Report issues, hallucinations, and security concerns to the team

## Real-World Scenarios

### ✅ Good Practice Example
**Task**: Generate a password validation function
- Prompt includes specific requirements (length, character types, regex compliance)
- Developer reviews output for security best practices
- Code is tested with edge cases
- Security review confirms no regex DoS vulnerabilities

### ❌ Problematic Practice Example
**Task**: "Generate database query"
- No security context provided
- Copilot generates basic SQL without parameterization (SQL injection risk)
- Code deployed without review
- Result: Security vulnerability in production

### ✅ Good Practice Example
**Task**: Create a REST API endpoint
- Prompt includes project structure, authentication method, and error handling requirements
- Copilot generates boilerplate code
- Developer reviews for proper validation, error handling, and security headers
- Automated tests verify functionality

### ❌ Problematic Practice Example
**Task**: "Write a function that processes user input"
- Prompt lacks security context
- Copilot generates code without input validation
- No review occurs; code moves to production
- Result: Input validation vulnerability
