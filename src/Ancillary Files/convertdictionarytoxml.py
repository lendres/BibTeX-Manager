"""
Created on May 14, 2023
@author: Lance A. Endres
"""

from unicodetolatex import unicode_codes_to_latex
file = open("LaTeX Tag Quality Processing.qlty", "w")

def WriteLine(line):
    file.write(line+"\n")

WriteLine('<?xml version="1.0" encoding="utf-8"?>')
WriteLine('<tagprocessorgroup name="Unicode to LaTeX" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">')

for key, value in unicode_codes_to_latex.items():
    WriteLine('\t<tagprocessor xsi:type="StringReplacementTagProcessor"')
    WriteLine('\t\tprocessalltages="true"')
    WriteLine('\t\tpattern="' + '\\u' + key + '"')
    WriteLine('\t\treplacement="' + value.replace('"', '&quot;') + '">')
    WriteLine('\t\t<tags></tags>')
    WriteLine('\t</tagprocessor>')

WriteLine('</tagprocessorgroup>')
file.close()