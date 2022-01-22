# names

- The project reads a txt input file, Splits the data into to two long strings: namesStr
and synonymsStr and then calls to four functions:

1) InputNames()- gets namesStr and returns it as a dictionary called "names" by working
on the string with methods like "split" and "replace".

2) InputNickNames()- gets synonymsStr and returns it as a dictionary called "nickNames"
by working on the string with methods like "split" and "replace".

3) FindCode()- determines a unique code for each name e.g: Jacob=1, Yaakov=1
Sara=5 and returns a new dictionary called "code" while the key is the name and the value
is the code.

4) Frequency()- calculates the frequency according to the above code dictionary and prints it. 

Input txt example:
------------------
Names: Jakob (5), Saara (5), Tommer (13), Jacov (15), Yaacov (5), 
Jacob (15), Yaakov (12), Tomier (13), Tommier (2), Tomer (14), Sara (19),  Shulamit (1), Shuli (1), Sheli (1), Leha (19), Lali (19), Yaacob (0)
Synonyms: (Tomer, Tomier), (Jakob, Jacob), (Jacob,
Yaakov), (Yaakov, Yaacov), (Yaacov, Jacov), (Leha, Lali), (Tommer, Tomer), (Saara, Sara), (Shuli, Shulamit), (Sheli, Shulamit), (Yaacob, Jacov), (Tomier, Tomer), (Tommier, Tomer)

Output example:
---------------
Jakob 52
Sara 24
Tomer 42
Shulamit 3
Lali 38

 
