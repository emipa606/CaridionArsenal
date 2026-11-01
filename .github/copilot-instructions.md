# GitHub Copilot Instructions for Caridion Arsenal (Continued)

## Mod Overview and Purpose

**Caridion Arsenal (Continued)** is an update to the popular RimWorld mod **Neildmacs**. The mod enhances the vanilla experience by adding new and unique weapons that can be crafted after completing specific research. It focuses on providing additional fun and variety for players on the desolate planet of RimWorld. The mod includes a variety of charged weapons, misc weapons, and other unique items to make the game more engaging.

## Key Features and Systems

### 1. New Weapons
The mod introduces several new weapons, including:
- **Charged weapons**: Such as Charge Pistol, Charge SMG, Charge Carbine, Charge Shotgun, Charge LMG, Charge DMR, Charge Sniper, Charge Minigun
- **Miscellaneous weapons**: Including Flechette Shotgun, Potato Launcher, Flamethrower, Coilgun, Taser Pistol, Taser Rifle, and Hyperboreal Rifle

### 2. Weapon Crafting
All new weapons are crafted at the **Machining table** after completing the relevant research. Each weapon variant has its own unique properties and values, offering a diverse range of options for colonists to choose from.

### 3. Texture Resolution
The weapons in the mod feature increased texture resolution based on forum originals, enhancing the visual experience.

## Coding Patterns and Conventions

### 1. C# Files
- **Projectile_SnowMaker.cs**: This file contains the definition for the `Projectile_SnowMaker` class, which is responsible for creating snow upon impact. The class includes:
  - **Impact()**: A method that handles the impact event of the projectile.
  - **snowCreation()**: A method that creates snow particles upon impact.

### 2. XML Files
- **Weapons_Guns.xml**: This XML file defines the various weapon types and their properties. It includes:
  - **ThingDef** elements for each weapon, specifying attributes such as name, description, texture, and stats.

## XML Integration

To integrate the new weapons into the RimWorld game, the mod uses XML definitions. Each weapon type is defined within the `Weapons_Guns.xml` file using the `ThingDef` element. The XML structure is as follows:

xml
<ThingDef>
    <defName>ChargePistol</defName>
    <label>Charge Pistol</label>
    <description>A pistol that fires charged rounds.</description>
    <category>Weapon</category>
    <comps>
        <li Class="CompProperties_VerbGiver">
            <verbs>
                <li>
                    <verbClass>Verb_Shoot</verbClass>
                    <verbProps Class="VerbProperties_Shoot">
                        <range>10</range>
                        <defaultProjectile>ChargeRound</defaultProjectile>
                    </verbProps>
                </li>
            </verbs>
        </li>
    </comps>
</ThingDef>


## Harmony Patching

The mod uses Harmony patching to integrate new functionality into the existing RimWorld codebase. Harmony is a powerful library that allows developers to modify game behavior without altering the original code. In the mod, Harmony patches are used to:

- **Add new research requirements**: Ensure that players can only craft the new weapons after completing the relevant research.
- **Modify weapon properties**: Adjust stats and behaviors of the new weapons to provide a balanced experience.

## Suggestions for Copilot

To assist in the development of the Caridion Arsenal (Continued) mod, Copilot can be used to:

### 1. Generate C# Code
- **Projectile Classes**: Create new projectile classes with the required impact methods.
- **Weapon Logic**: Implement logic for new weapons, such as unique effects or behaviors.

### 2. Generate XML Definitions
- **ThingDef Elements**: Define new weapon types and their properties using the `ThingDef` element.
- **ResearchDefs Elements**: Create research definitions for the new weapons.

### 3. Code Review and Refactoring
- **Review C# Code**: Analyze the existing C# code for best practices and potential improvements.
- **Refactor XML**: Optimize XML structures for better readability and performance.

### 4. Documentation
- **README.md**: Update the README file with detailed information about the mod, including installation instructions, compatibility, and a list of new weapons.
- **XML Comments**: Add comments to the XML files to explain the purpose and functionality of each element.

## Example Usage

### Generating a New Projectile Class

csharp
public class Projectile_ChargedRound : Projectile
{
    public override void Impact(Thing hitThing)
    {
        base.Impact(hitThing);
        // Add custom impact logic for the charged round
    }

    public void CreateExplosion()
    {
        // Code to create an explosion effect
    }
}


### Generating a New Research Definition

xml
<ResearchProjectDef>
    <defName>Research_ChargeWeapons</defName>
    <label>Charge Weapons Research</label>
    <description>Unlock the ability to craft charged weapons.</description>
    <prerequisites>
        <li>Research_Machining</li>
    </prerequisites>
    <fields>
        <li>ResearchField_Technology</li>
    </li>
    <baseCost>2500</baseCost>
    <techLevel>Advanced</techLevel>
    <icon>UI/ResearchIcons/ChargeWeapons.png</icon>
</ResearchProjectDef>


By following these guidelines, Copilot can be effectively utilized to enhance the Caridion Arsenal (Continued) mod, ensuring a seamless integration of new weapons and features into the RimWorld game.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).
- When mentioning SonarQube issues, automatically use the SonarQube MCP service to fetch and address issues instead of making inferred fixes without querying SonarQube first.
- When mentioning the rimworld log, automatically use the Rimworld MCP service to fetch the log.

