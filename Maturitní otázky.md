# 1. Zobrazení dat v počítači
- základní stavební jednotky -- bit
- byte jen proto, že se tak někdo rozhodl
- vše v počítači je uloženo jako čísla

## Reprezentace celých čísel
- beze znaménka
- se znaménkem -- _dvojkový doplňek_
  - u záporných se _prohodí všechny 1 a 0 a přičte se 1_ (aby nebyla -0)
  - sčítání funguje stejně jako u desítkové

## Reprezentace desetinných čísel
- plovoucí -- [znaménko | číslo | exponent] -> `znaménko * číslo ^ exponent`
  - _znaménko_ je 1 bit -- zda je číslo kladné nebo záporné
  - _číslo_ je unsigned int
  - _exponent_ je signed int
- pevné -- `číslo.číslo`
  - rychlejší počítání, úplná přesnost, ale menší rozměr
  - používáno třeba u grafických karet

## Znak, Pole, řetězec, struktura
- kombinace základních stavebních bloků (čísel)


# 2. Dvojková, desítková a šestnáctková číselná soustava
- na dvojkové je _založen počítač_
- desítková je _používaná lidmi_
- šestnáctková je používána _pro kratší zápis_
- všechny z nich jsou jsou _poziční_ -- záleží na pořadí cifer

## Desítková - dekadická
- používá `0-9`
- ukázat princip fungování + rozvinutý zápis čísla
- 1 a spousta 0 -- _mocnina desítky_

## Dvojková - binární
- ukázat úplně to samé jako u desítkové

## Šestnáctková - hexadecimální
- ukázat úplně to samé jako u desítkové

## Uvést příklady
- převod z `2 do 10`
- převod z `10 do 16`
- převod z `10 do 2`


# 3. Jednoduché datové typy

## Základní číselné typy
- `byte n = 123;`
- `int n = 123414;`
- `float n = 1.512;`
- dávat si pozor na přetypování -- z větší do menší
  - `int n = (int)round(f);`

## Základní operace
- sčítání, odčítání, násobení, dělení, modulo
- `long result = a + b - c * d / e % f`
- celočíselné dělení x desetinné dělení

## Znak
- `char c = 'a'`
- uvést příklady

## Bool
- `bool b = a < c;`
- jaké hodnoty nabývá

## Vyjmenovaný typ
```python
class Color(Enum):
  RED = 1
  GREEN = 2
  BLUE = 3
```

# 4. Strukturované datové typy
- strukturované -- složené ze základních

## pole
- `int[] pole = new int[10];`
- nakreslit obrázek a dát příklad ukládání (indexování)
- jak se zjišťuje délka pole
- vypisování všech hodnot přes normální `for(int i)`
- `foreach(int cislo in pole)` -- syntactic sugar

## řetězec
- `string s = "ahoj";`
- `s = s + "5";`

## struktura
- rozdílné datové typy
- chová se to jako objektově orientované programování
- funguje i bez `new` (je to hybrid)
- `struct s = {int a; int b; s() {}}`


# 5. Přiřazovací a podmíněný příkaz
- co je to přiřazující výraz: `int x = 0;`
- kompaktnější přiřazení - `x += 1;`, `x++;`
- if, else, if else
- aritmetické porovnávání
- zkrácené vyhodnocování
- logické spojky - and, or, not, xor
- switch


# 6. Cykly
- k čemu jsou
- `while()`
- `do ... while()`
- `for(int i = 0; i < N; i++) {}`


# 7. Práce se soubory
- soubory -- _shluk jedniček a nul_
  - binární -- custom struktura
  - textový -- ukládá text
- ukládání -- ukončí se čtení, přepíše se a opět se zamkne pro čtení

```python
with open("file.txt", "r") as f:
  print(f.read())

with open("file.txt", "w") as f:
  f.write("Ahoj")
```


# 8. Podprogramy
- používání funkcí -- _program je přehlednější, kód je kratší_
- klíčová slova
  - return type: `void`, `int`, ...
  - `int mocnina(int i){return i * i;}`
  - formální (předpis) x skutečný (reálná hodnota) parametr


# 9. Typy předávání parametrů, lokalita proměnných
- rozsah platnosti proměnných = **scope**
- hodnotové jsou odebírány **ze stacku,**, referenční **garbage collectorem**

## Class-level scope
- proměnné třídy jsou k dispozici všem nestatickým metodám třídy
- statické metody jsou k dispozici všem metodám třídy

## Method-level scope
- proměnné deklarované uvnitř metody jsou k dispozici v metodě
- pro přístup k metodám třídy se stejným jménem použijeme `self.xxx` (nebo `this.xxx` v C#)


# 10. Náhodná čísla
- v počítači _neexistují opravdu náhodná čísla_ -- algoritmus je vždy stejný
    - při stejné konfiguraci generuje stejná čísla
- pseudonáhodné generátory čísel dostanou _seed_ (počáteční číslo) a poté pomocí matematických funkcí generují další prvky

## Příklady
- desetinné číslo: `random.random()` -- náhodné desetinné číslo
- `random.seed(...)` -- seed
- celé číslo: `random.randint(lower, upper)` -- náhodné celé číslo v rozmezí `lower, upper` (včetně)
  - alternativní varianta: `(random.random() * (upper - lower) + lower)`


# 11. Kreslení
- obrázek se skládá z pixelů
- souřadnice z levého horního rohu
- RGB barvy
- 0/255 barvy
- kreslení pomocí QPainteru

# 12. Úpravy rastrů
- Bitmap třída
  - `Color p = img.getPixel(0, 0);`
  - `img.setPixel(p, 0, 0);`
- popsat zdrojáky částí programů na úpravu věciček
- zvětšování 2x -- z 1 jsou 4
- zmenšování -- _neprůměrujeme_, vezmeme pouze 1 ze 4
- filtrování -- červená, 0, 0 (to samé pro ostatní)
- rotace -- for-cykly a opisuje se
- převádění do šedi -- _vážené_ průměrování
  - jen B&W -- hranice 127
  - _distribuce chyby_ - rozdělí se mezi 4 ještě neprolezené sousedy


# 13. Algoritmy vnitřního řazení a jejich složitost
- řazení
  - _vnitřní_ -- všechna data se vejdou do operační paměti (RAM)
  - _vnější_ -- musí se jít do souboru, kde se nemůže indexovat (HDD)

## Dělení
- _stabilní_ -- struktury se stejným číslem _budou pokaždé na stejném místě_
- _nestabilní_ -- struktury se stejným číslem _nemusí skončit na stejném místě_

# Složitost
- `O(n^2)`
  - výběr minima (najdu a vyměním)
  - třízení vkládáním (posouvání hranice)
  - bublinky (prohazování, dováží nakonec největší)
  - _quicksort_ (průměr je však `O(n log(n))`, ukázat příklad)
- `O(n log(n))` -- mergesort, heapsort
- `O(n)` -- přihrádkové řazení (pokud jsou největší a nejmenší prvek dány)


# 14. Hodnotové a referenční datové typy
- co je to proměnná?

## Typy
- _primitivní_ - uvést příklad: `int i = 5;`
- _referenční_ - uvést příklad: `int[] i = new int[15];`
    - vysvětlit `new`
    - přidat ilustraci -- new je jen pointer
- ukázka přiřazení, hlavně co kam ukazuje
  - `int a = b;`
  - `int[] a = b;`
- funkce na přidávání hodnoty k proměnné -- `add`
- garbage collector -- na rozdíl od jazyků jako C probíhá automaticky


# 15. Lineární spojový seznam
- nakreslit _jednosměrný_ x _obousměrný_ (2 pointery -- začátek a konec)
  - (buňky se samostatnými daty a ukazatele na další prvek v pořadí; v případě obousměrného i na předchozí)
- _THE GOOD:_ přidání na konec v `O(1)`, odebrání prvku z konce v `O(1)` (pro obousměrný)
- _THE BAD:_ vyžaduje více paměti
- _THE UGLY:_ přístup na n-tý index trvá `O(n)`

## Implementace
- třída `node`, která má referenci a hodnotu
- postupné připojování nodů za sebe


# 16. Metody vyhledávání v poli a lineárním spojovém seznamu
Porovnání rychlostí hledání
|      | first/last | i-th | specific value | sp. value in sorted |
|------|------------|------|----------------|---------------------|
| LSS  | O(1)       | O(i) | O(n)           | O(n)                |
| Pole | O(1)       | O(1) | O(n)           | O(log n)            |

## Binární vyhledávání
- půlení intervalu -- odstranění toho intervalu, ve kterém prvek jistě není
- pokud se nakonec `start > end`, tak prvek v poli není


# 17. Binární halda
- _speciální příklad binárního stromu_
  - buďto perfektně vyvážený, nebo _doplňovaný zleva_
  - _otec je větší než synové_
- v paměti ji lze ukládat jako _pole_
- nakreslit haldu
  - ukázat operace: přidání, odebírání, nastínit třízení


# 18. Rekurze
- _přímá_ rekurze - funkce volají v rámci svého fungování samy sebe
- _nepřímá_ rekurze - více funkcí se volají navzájem
- ukázat příklad faktoriálu v pythonu (`n == 0`)
- příklady:
  - procházení stromu do hloubky
  - quicksort
  - součet čísel všemi kombinacemi


# 19. Binární vyhledávací stromy
- binární strom, ve kterém je otec _větší než všichni synové v levém podstromě_ (a menší než v levém)
- implementace přes třídu
- vyhledávání prvku (vždy jdeme doleva/doprava podle velikosti vrcholu)
- přidávání prvků (jdeme daným směrem, jakmile přepálíme tak obráceně)
- ubírání -- list je triviální, jinak prohodíme s prvkem jednou doleva a poté pořád doprava (nebo obráceně)


# 20. Zásobník a fronta
- pomocné datové struktury, do kterých si odkládáme data a ve správném pořadí je vybíráme
- _zásobník_ -- talíře
    - použití např. při rekurzi
- _fronta_ -- fronta do kina
- _pop, peek, append, length_
- fronta přes stack -- přidávání na začátek, end na konec


# 21. Průchod binárního stromu
- graf
  - nemá kružnice -> je to les
  - je spojitý -> je to strom
  - každý vrchol má nejvýše dva syny -> je to binární strom
- pojmy
  - vrcholy a hrany
  - úrovně
- _žádné vlastnosti_ (až na výše vyjmenované) _neplatí!_

## Procházení
- do hloubky - začínáme v kořeni, kontrolujeme doleva a doprava
  - použijeme stack / rekurzi (vlastně to samé)

```
def explore_tree(node):
  print(node.value)

  if node.left_child is not None:
    explore_tree(node.left_child)
  if node.right_child is not None:
    explore_tree(nore.right_child)
```

- přehazováním `print(node.value)` měníme způsob vypisování prvků
  - před -- pre-order (vypíše se hned každý navštívený)
  - mezi -- in-order (vypíše se, když se pokusím jít doprava)
  - po -- post-order (vypíše se, až budou všichni jeho synové navštíveni)
- vše je to do hloubky -- každý vrchol navštívím tolikrát, kolik má synů + 1 (otec)

- procházení přes stack (místo rekurze)
  - _LEFT A RIGHT JE OPROTI FRONTĚ PROHOZENÉ,_ aby se nejdříve popnul levý
```
stack = [root]

while len(stack) != 0:
  node = stack.pop()
  print(node.value)

  if node.right_child is not None:
    stack.append(node.right_child)
  elif node.left_child is not None:
    stack.append(node.left_child)
```

# 22. Aritmetický výraz
- aritmetický výraz -- + - * / (+ čísla a závorky)
- geometrický výraz -- přidáme proměnné

## Reprezentace výrazu
Nakreslit příklad se všemi operátory a jejich převody.
- infix (1 + 2)
- postfix (1 2 +)
- strom
    - v kořeni je operátor, který se vykoná _jako poslední_
    - čísla jsou listy a jsou _zleva seřazena_


# 23. Metody reprezentace grafů
- co je to graf (nakreslit příklad)
- zapsání do matice (matice sousednosti) -- nakreslit příklad
- pole spojáků
- dvě pole - spojáčky dáme za sebe - počet indexů + 1; počet hran
  - v prvním poli řeknu, kolik hran následuje

## Dijkstra
- graf musí být konečný a orientovaný
- hodnoty hran musí být nezáporné
- nastav sebe na 0 a zbytek na nekonečno
- cyklus:
  - ze všech dočasných vyber tu nejlepší (binární halda)
  - prohlas ji za trvalou


# 24. Objekty
- vzniklo z _procedurálního programování_ -- lepší reprezentace objektů z reálného světa a zapouzdřovat jejich stav i chování
- _Třída_ -- představuje _předpis,_ jak vytvářet objekty -- např. zvíře má věk, hmotnost... (doplnit ukázkou)
- _Objekt_ je _instancí třídy_ -- konkrétní zvíře (doplnit ukázkou)

## Obsah třídy
-	proměnné
-	metody (chování a operace které můžeme nad objektem provést)
-	konstruktor (vytváření objektů)
  - může obsahovat parametry, kterými inicializuje stav objektu


# 25. Správnost programu
- syntaktická (`iff 1 == 1`) x sémantická (`int x = "ahoj;"`) x logická (chyba v uvažování)
  - ukázat příklady
- typy debugování
  - _print debugování_ -- print statementy vypisující stav proměnných
    - jednodušší a rychlejší, může však trvat déle
  - _debugger_ a _break pointy_
    - program se v určených místech zastaví a zahlásí vnitřní stav
    - možnost stepování
