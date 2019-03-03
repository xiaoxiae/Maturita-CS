# 1. maturitní otázka
- základní stavební jednotky - bit
- byte jen proto, že se tak rozhodli
- vše v počítači je uloženo jako čísla

## Celá čísla
- beze znaménka
- se znaménkem - dvojkový doplňek
  - nezapomenout zmínit, že se prohodí všechny 1 a 0 a nakonec se k tomu přičte 1 aby nebyla -0
  - sčítání - normální jako u 10kové

## Desetiná čísla

### Plovoucí
- znaménko | číslo | exponent
  - znaménko je 1 bit - zda je číslo kladné nebo záporné
  - číslo a exponent - unsigned čísla
  - zmínit, že se desetinná čárka nejprve posune za mantissu

### Pevná
- rozstřihnutí do celé a desetinné části
- rychlejší počítání, přesnost
- používáno třeba u grafických karet

## Znak
- číslo, podle enkódování něco reprezentuje
- ASCII - 128 (či 256) bitů
  - anglická abeceda, symboly a speciální znaky - tab, nová linka
- UTF-8 - pokrývající zbytek symbolů zbylých abeced

## Pole, řetězec, struktura
- kombinace základních stavebních bloků do jedné věcičky


# 2. maturitní otázka
- 2ková pracuje ve dvojkové soustave
- 10ková je používaná lidmi
- 16ková je pro kratší zápis
- jsou POZIČNÍ - záleží na pořadí

## Desítková - dekadická
- používá 10 symbolů - 0 až 9 - nejmenší je 0, největší je 9
  - když dojde symbol, tak se napíše opět nejmenší a to před tím o 1 zvětší - tohle ukázat
- rozvinutý zápis čísla
- 1 a spousta nul - mocnina desítky

## Dvojková - binární
- 2 symboly - 0 a 1
- platí pro ní stejné věci jako pro desítkovou - ukázat výčet
- rozvinutý zápis čísla
- 1 a spousta nul - mocnina dvojky

## Šestnáctková - hexadecimální
- symboly - 0 až 9 a a, b, c, d, e, f
- výčet
- rozvinutý zápis čísla
- 1 a spousta nul - mocina 16

## Příklad převodu z 10 do 2
## Příklad převodu z 10 do 16
## Příkad převodu z 2 do 10 - obrácení postupu


# 3. maturitní otázka

## Základní číselné typy
- `byte n = 123;`
- `int n = 123414;`
- `float n = 1.512;`
- dávat si pozor na přetypování - z větší do menší
  - `int n = (int)round(f);`

## Základní operace
- sčítání, odčítání, násobení, dělení, modulo
- `long result = a + b - c * d / e % f`
- celočíselné dělení x desetinné dělení

## Při použití knihovny
- všechno ostatní - sin, cos, log...

## Znak
- uvést příklady
- `char c = 'a'`

## Bool
- jaké hodnoty nabývá
- `bool b = a < c;`


# 4. maturitní otázka
- strukturované - složené z těch základních

## pole
- `int[] pole = new int[10];`
- nakreslit obrázek a dát příklad ukládání
- jak se zjišťuje délka pole
- vypisování všech hodnot přes normální `for(int i)`
- `foreach(int cislo in pole)` - menší uplatnění

## řetězec
- `string s = "ahoj";`
- `s = s + "5";`

## struktura
- rozdílné datové typy
- chová se to jako objektově orientované programování
- funguje i bez `new` (je to hybrid)
- `struct s = {int a; int b; s() {}}`


# 5. maturitní otázka
- co je to přiřazující výraz: `int x = 0;`
- kompaktnější přiřazení - `x += 1;`, `x++;`
- if, else, if else
- aritmetické porovnávání
- zkrácené vyhodnocování
- logické spojky - and, or, not, xor
- switch


# 6. maturitní otázka
- `while()`
- `do ... while()`
- `for(int i = 0; i < N; i++) {}`


# 7. maturitní otázka
- soubory - shluk jedniček a nul - každý by šlo otevřít jakýmkoliv programem
  - záleží na typu souboru
    - binární - připravení správných proměnných na čtení
    - textový - co řádek, to string
- ukládání - ukončí se čtení, přepíše se a opět se zamkne pro čtení
- připravit si ukázku čtení a psaní přes Python


# 8. maturitní otázka
- používání funkcí - program je přehlednější, kód je kratší
- klíčová slova
  - return type: `void`, `int`, ...
  - `int mocnina(int i){return i * i;}`
  - formální (předpis) x skutečný (reálná hodnota) parametr


# 10. maturitní otázka
- v počítači neexistují opravdu náhodná čísla - algoritmus je stejný, takže při stejné konfiguraci by to generovalo stejná čísla
- pseudonáhodné generátory čísel - dostanou seed a poté pomocí matematických funkcí generují další prvky
  - seed - počáteční číslo, od kterého se výsledky odvíjejí
    - hlavně kvůli testování - chová se pokaždé stejně
- C# example
  - desetinné číslo
  - celé číslo - .next(hodni), .next(dolni, horni)
  - `(int)(r.next() * (horni - dolni) + dolni)`
