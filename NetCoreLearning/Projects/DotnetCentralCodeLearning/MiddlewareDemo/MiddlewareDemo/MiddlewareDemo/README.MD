## IApplicationbuilder Use vs UseWhen vs Map vs Run vs MapRun

Run => this mehtod will **terminate** the middleware. The middleware after run method will not be called. 

Use => this method allows **route to next middleware**. However, if next() method is not called, then, it behaves the same as Run method does.
       also, we can put logic after next() method. It behaves like function invokation.

UseWhen => This method creates a **conditional** branch of middleware. After it finishes, it will rejoin back to the main pipeline

Map => This method creates a branch when **path** is set and matches. Map support hierarchy and we can call another app.Map inside the parent one 

eg.

`
app.Map("/map", a => {
    a.Run(async context => {
        await context.Response.WriteAsync($"new map branch");
    });
    
});
`

MapRun => this method is silimar as UseWhen but the difference is that it will **NOT** rejoin back to the main pipeline