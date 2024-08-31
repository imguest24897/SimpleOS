# SimpleOS
SimpleOS is a lightweight, fast, and user-friendly operating system developed with Cosmos in Visual Studio 2022. Designed for simplicity and efficiency, it offers a streamlined experience while showcasing the power of modern OS development. Explore the code and contribute to this minimal yet functional OS!
## Error codes:
### DUMMY_KERNEL_PANIC
An dummy kernel panic caused by user.
### FORCE_BOMB_ACTIVATED
Same as dummy kernel panic caused by user.
### MEMORY_STACK_OVERFLOW
Memory stack is overflowed.
### DRIVER_EXCEPTION_INITIALIZATION_FAILED
[CRITICAL!] Driver has failed to initialize.
### MEMORY_CORRUPTED
[CRITICAL!] Your RAM is corrupted. There is a 98% chance your computer won't start up again if this happends.
### KERNEL_EXCEPTION
[CRITICAL!] An exception was throwed by the kernel.
### INCORRECT_BOOT_CONFIGURATION
[CRITICAL!] Your boot configuration is incorrect.
### GPU_FAILURE
[CRITICAL!] GPU fails to render. Good thing to help you know if your GPU fails.
## What about root access?
Not implemented.
## How to compile it?
### Install Visual Studio 2022 and Cosmos
Visual Studio 2022: https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=Community&channel=Release&version=VS2022&source=VSLandingPage&cid=2030&passive=false
Cosmos: https://www.gocosmos.org/download/
> Note: It is recommended to use Userkit.
### Opening the SimpleOS.csproj file and compiling
Press Ctrl + B to build SimpleOS.
> Note: If you have a solution of it, you can press F7 to build the solution.
### Where did it put ISO?
After that, you can find the ISO in the following folder where you downloaded SimpleOS source:
bin\Debug\net6.0
