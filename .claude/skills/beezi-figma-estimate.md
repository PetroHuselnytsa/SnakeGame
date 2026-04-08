---
name: beezi-figma-estimate
description: Extract exact design tokens from Figma before estimating task complexity. Every value must be real — no approximations.
---

# Figma Estimation Protocol

You MUST follow this protocol before scoring estimation clarity. The goal is to extract the **exact** design specification from Figma so estimation reflects real implementation complexity.

## Step 1 — Fetch Figma Data

Call `get_figma_data` for every Figma URL provided in the task context. Use ONLY `get_figma_data` — never WebFetch or Bash.

If any URL fails, lower your confidence score and list the failed URLs as concrete unknowns.

## Step 2 — Extract Exact Design Tokens

Extract these **exact values** from the Figma data. Not approximations. Not "close to". The real values:

- **Colors**: exact hex or rgba values (e.g. `#1A2B3C`, `rgba(26, 43, 60, 0.8)`)
- **Spacing**: exact padding, margin, and gap values in px
- **Typography**: exact font-family, font-size, font-weight, line-height, letter-spacing
- **Borders**: exact border-radius, border-width, border-color
- **Shadows**: exact box-shadow values
- **Opacity**: exact opacity values
- **Dimensions**: exact width/height constraints
- **Icons**: exact sizes

Document every token you extract. If a value cannot be read from Figma, flag it as **UNKNOWN** — never guess.

## Step 3 — Identify Target Frame and Ambiguities

- Identify the exact target frame/state that matches the task
- If multiple states fit (empty vs populated, etc.), note each as a separate implementation scope item
- List all ambiguities — anything not clearly specified in the Figma design

## Step 4 — Derive Implementation Scope

Using the extracted tokens and identified frames:
- List all components, states, and interactions visible in Figma
- Count the number of unique design tokens that must be implemented exactly
- Identify which tokens match existing codebase tokens and which require new values
- Assess complexity based on the real design, not assumptions

## Step 5 — Score Estimation

Use the derived scope to:
- Adjust the estimation score based on actual design complexity
- Identify highest-risk assumptions (tokens that couldn't be read, ambiguous states)
- Produce a realistic execution plan

If target state is ambiguous, lower confidence and list concrete unknowns in the output. Do not assume any state not evidenced by Figma.
