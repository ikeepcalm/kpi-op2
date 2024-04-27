# Strings

## Get Valid Name
Write **GetValidName** method that takes string parameter  **nameToValidate** (words separated by spaces) and returns the string obtained after conversion in which:

- all words are separated by single spaces

- the first letter of each word in upper case, the rest - in lower case

- all words contain only Latin characters, others are deleted

- line length - maximum 50 characters, the rest are cut off

The method throws an ArgumentException if the input string is missing or zero-length or if the output string is empty. 


Example 

```
nameToValidate =  “Sam   bRoWn    ”        result =  “Sam Brown” 
nameToValidate =  “  Sam68    ”        result =  “Sam”
```

