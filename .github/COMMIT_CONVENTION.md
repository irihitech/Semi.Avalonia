# Git Commit Message Convention

This project follows the [Conventional Commits](https://www.conventionalcommits.org/) specification for commit messages.

## Format

```
<type>[optional scope]: <description>

[optional body]

[optional footer(s)]
```

## Types

| Type | Description |
|------|-------------|
| `feat` | A new feature |
| `fix` | A bug fix |
| `docs` | Documentation only changes |
| `style` | Changes that do not affect the meaning of the code (formatting, missing semicolons, etc.) |
| `refactor` | A code change that neither fixes a bug nor adds a feature |
| `perf` | A code change that improves performance |
| `test` | Adding missing tests or correcting existing tests |
| `build` | Changes that affect the build system or external dependencies |
| `ci` | Changes to CI configuration files and scripts |
| `chore` | Other changes that don't modify source or test files |
| `revert` | Reverts a previous commit |

## Rules

1. **Limit the subject line to 50 characters** (72 character hard limit)
2. **Use the imperative mood** in the subject line (e.g., "add feature" not "added feature")
3. **Do not end the subject line with a period**
4. **Use lowercase** for the description (e.g., "add feature" not "Add feature")
5. **Separate subject from body with a blank line**
6. **Wrap the body at 72 characters**
7. **Use the body to explain what and why**, not how
8. **Reference issues and pull requests** in the footer

## Scope

The scope should be the name of the package or area affected (e.g., `button`, `datepicker`, `theme`, `demo`).

## Examples

### Simple commit

```
feat(button): add loading state support
```

### Commit with body

```
fix(datepicker): correct month navigation overflow

When navigating past December, the month index wrapped to a
negative value instead of rolling over to January of the next year.
```

### Commit with breaking change

```
feat(theme)!: rename SemiColorPrimary to SemiColorBrand

BREAKING CHANGE: The token SemiColorPrimary has been renamed to
SemiColorBrand. Update all references in your custom theme files.
```

### Commit referencing an issue

```
fix(textbox): placeholder not visible in dark mode

Closes #123
```

## Breaking Changes

Breaking changes must be indicated by appending a `!` after the type/scope, or by including a `BREAKING CHANGE:` footer. Both methods may be used together.

## Revert Commits

When reverting a previous commit, use the `revert` type and reference the reverted commit SHA in the footer:

```
revert: feat(button): add loading state support

Revert commit a1b2c3d.
```
