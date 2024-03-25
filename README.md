# This is my 3D Pacman Game!

## Code Conventions naming:

I use CamelCase for naming my Variables.

if the variable isn't called from another class or if you dnon't think you're gonna use it outside the class its automaticly a private var.
```yaml
[serializefield] private string camelCase;

private string _camelCase;

public string CamelCase;
```
-------
## Code Convention conditions:

By If-statements: if the lines in the statements is not more than one don't use brackets

Example:

```yaml
var result = true

If(result)
  print("It works!")
else
  print("it didn't work") 
```


The reason why because its unneccesary to use brackets by one lined code statements and this is more readable.

another expression is to use ? and : 

Example:

```yaml
int x = 10;
int y = 20;

int result = x > y ? x : y;
```

what i am saying here is that if x is higher than y then is x the result, but if x is lesser than y, y is then the result.

-------
