# kOS/Kerbalism Bridge

This provides a custom kOS addon to enable working with Kerbalism experiments from scripts.

## Installation

* Copy `GameData/Kerbalism/Kerbalism112.kbin` to `GameData/Kerbalism/Kerbalism.dll` in your KSP installation.
  * If you know how to make this mod depend lazily on Kerbalism so that the kerbalism loader will work right,
    please let me know!
* Copy `GameData/kos_kerbalism` to your KSP installation

You can confirm the mod is installed correctly in kOS with `print ADDONS:AVAILABLE("KERBALISM").`

## Usage

The following custom suffixes are added to kerbalism module types

### `Experiment`

* `DEPLETED` - returns `true` if this experiment has a limited sample size and it has been used
  up. Never returns `true` for experiments which collect their samples from the environment. This
  will return `true` even in cases when the kerbalism PAW might prefer to show a different error
  before checking the depleted status.

### `HardDrive`

* `TRANSFERHERE()` - Equivalent to pressing the "transfer here" button in the PAW

### `ProcessController`

* `START()` - Equivalent to pressing the "toggle" button in the PAW when the process is not running. 
  Does nothing if it is already started. Processes cannot be started when they are broken.
* `STOP()` - equivalent to pressing the "toggle" button in the PAW when the process is running.
  Does nothing if it is already stopped. Processes cannot be stopped when they are broken.
* `BROKEN` - returns `true` if the process is disabled because of a failure.
* `RUNNING` - returns `true` if the process is started. Can return `true` even if the module is broken.
* `ACTIVE` - returns `true` if `RUNNING and not BROKEN`
* `TITLE` - returns the title of the process
