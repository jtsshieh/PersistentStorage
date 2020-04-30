# Queries

Queries allow you to access and update data from an object without a cache.

## Structure

Queries use a dots to access properties. For example, if we have an object like this:

```json
{
    "number" : 10
}
```

the query to access the `number` property would just be `number`.

If we have nested object like this:

```json
{
    "settings" : {
        "letter" : "a",
        "happy" : true,
        "number" : 0
    }
}
```

we can access `letter` with `settings.letter`.

If we have an array like this:

```json
{
    "array" : [0, 2, 4, 6 ,8]
}
```

we can access the 3rd item with `array[2]`.
