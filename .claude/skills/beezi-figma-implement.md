---
name: beezi-figma-implement
description: Enforce pixel-perfect Figma fidelity during implementation. Every color, padding, spacing, font, and visual property must be identical to Figma. Any deviation causes PR rejection.
---

# Figma Design Implementation — Pixel-Perfect Enforcement

Your implementation MUST be an exact copy of the Figma design. Every color, every padding, every spacing value, every font property — identical. **Any deviation from Figma will cause PR rejection.**

This is not a guideline. This is a hard requirement.

## Step 1 — Fetch Figma Data

Call `get_figma_data` for every Figma URL provided in the task context. Use ONLY `get_figma_data` — never WebFetch or Bash.

If ANY URL fails to load, **STOP immediately**. Do not implement from assumptions. Report a blocked outcome listing exactly which URLs failed.

## Step 2 — Extract Every Design Token

Before writing a single line of code, extract these **exact values** from Figma:

| Category | What to extract |
|----------|----------------|
| **Colors** | Every hex/rgba value — backgrounds, text, borders, icons, shadows, overlays |
| **Spacing** | Every padding, margin, and gap value in px |
| **Typography** | font-family, font-size, font-weight, line-height, letter-spacing for every text style |
| **Borders** | border-radius, border-width, border-color for every element |
| **Shadows** | Complete box-shadow values (offset, blur, spread, color) |
| **Opacity** | Opacity for every element that isn't fully opaque |
| **Dimensions** | Width, height, min/max constraints |
| **Icons** | Exact sizes and colors |

Document all extracted tokens. If a value cannot be read, flag it as **UNKNOWN** and ask for clarification — do not guess or approximate.

## Step 3 — Build Design Contract

Before coding, document:
- **IA structure**: sidebar, topbar, tabs, sections, layout hierarchy
- **Component inventory**: exactly what exists in Figma and what does NOT
- **UI states**: empty, loading, populated, error, disabled, hover, active, focus — only those shown in Figma
- **Responsive behavior**: any responsive constraints visible in the design

## Step 4 — Implement with Exact Values

Rules — no exceptions:

1. **Use the exact color values from Figma.** If Figma says `#2563EB`, your code uses `#2563EB`. Not `#2564EB`. Not `blue-600`. Not "a similar blue". The exact hex value. If a codebase design token happens to match the Figma value exactly, you may use that token — but verify it resolves to the identical value first.

2. **Use the exact spacing values from Figma.** If Figma says 16px padding, your code uses 16px. Not 1rem (unless 1rem = 16px in the project and you have verified this). Not `p-4`. The exact value.

3. **Use the exact typography from Figma.** If Figma says Inter 14px/20px Semi Bold, your code uses font-family Inter, font-size 14px, line-height 20px, font-weight 600. Exact match.

4. **Use the exact border-radius, shadows, and opacity from Figma.** No rounding. No approximations.

5. **Implement ONLY what Figma shows.** Do not add components, sections, buttons, or controls that are not in the target frame. Do not add UI states that Figma doesn't show.

6. **Figma wins over codebase patterns.** If the codebase uses `rounded-lg` but Figma specifies `border-radius: 6px` and `rounded-lg` resolves to `8px`, use `6px`. Document the conflict but follow Figma.

## Step 5 — Fidelity Self-Check

Before finalizing your implementation, verify **every element** against the Figma design:

- [ ] Colors match exactly (compare hex values)
- [ ] Padding values match exactly (compare px values)
- [ ] Margin values match exactly (compare px values)
- [ ] Gap values match exactly (compare px values)
- [ ] Font family matches exactly
- [ ] Font size matches exactly
- [ ] Font weight matches exactly
- [ ] Line height matches exactly
- [ ] Letter spacing matches exactly
- [ ] Border radius matches exactly
- [ ] Border width and color match exactly
- [ ] Box shadows match exactly
- [ ] Opacity matches exactly
- [ ] Element dimensions match constraints
- [ ] Component presence/absence matches Figma
- [ ] Layout structure and hierarchy match Figma
- [ ] No extra components or sections were added

**If ANY item doesn't match, fix it before completing.** Mismatches will cause PR rejection.
