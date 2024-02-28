# Raha sovellus

## Kuvaus

Raha sovellus on työpöytäsovellus, jonka avulla käyttäjät voivat hallita henkilökohtaisia rahojaan lataamalla tiliotteensa CSV-tiedostona. Sovelluksella voi kategorisoida tulot ja menot, jotta voit seurata rahankäyttöäsi helpommin. 

Sovelluksen toimintaperiaate perustuu tiliotteen csv-tiedostoon, joka sisältää tietoja kuten määrän, päivämäärän ja saajan. Esimerkiksi HSL:n maksut ilmenevät nimellä `HSL MOBIILI` tai `hsl mobiili`. Nämä ovat niin sanottuja avainsanoja, joiden avulla sovellus pystyy tunnistamaan HSL:n tapahtumat matkakuluiksi.


## Ominaisuudet

- Tiliotteiden lataaminen CSV-muodossa.
- Tulojen ja menojen kategorisointi.
- Kategorioiden muokkausmahdollisuus.
- Tulosten ja menojen yhteenveto.

## Käyttö

Ladattuasi sovelluksen, sinun tulee purkaa se. `Release`-kansiossa on exe-tiedosto nimeltä `Raha tuhlaus laskuri`, jonka avulla voit avata sovelluksen.

### Perusominaisuudet

Sovelluksen vasemmassa alakulmassa on kaksi nappia: `Lisää` ja `Uusi`. Näiden nappien avulla voit lisätä csv-tiedostoja sovellukseen. `Lisää`-nappia painamalla voit lisätä uuden csv-tiedoston, ja sinulla voi olla useita csv-tiedostoja ladattuna samaan aikaan. `Uusi`-nappia painamalla sovellus poistaa rekisteristä vanhat csv-tiedostot ja lisää uuden.

Näiden nappien oikealla puolella on `Tulot` ja `Menot` -napit. Näitä painamalla voit suodattaa näkymään joko vain tulot tai menot.

Kun olet ladannut csv-tiedoston, voit valita sille kategorian vasemmalla olevan taulukon viimeisestä sarakkeesta. Oikealla puolella olevaan taulukkoon ilmestyvät kategoriat. Painamalla tiettyä kategoriaa vasemman puolen taulukossa, näet vain kyseisen kategorian menot ja/tai tulot.

### Kategorian lisääminen

Vasemmassa yläkulmassa on `Menu`-alasvetovalikko, josta löytyy `Muokkaa kategorioita` -nappi. Tätä painamalla pääset uudelle välilehdelle, jossa voit muokata, lisätä tai poistaa kategorioita.

Vasemmalla olevassa `Kategoriat`-taulukossa näkyy kaikki kategoriat. Sen alapuolella on mahdollisuus lisätä, muokata tai poistaa kategorioita. Oikealla olevassa `Avainsanat`-taulukossa näkyy kaikki tietyn kategorian avainsanat, joita voi myös lisätä, poistaa tai muokata.


## Tuki

Jos tarvitset teknistä tukea tai sinulla on kysyttävää, lähetä sähköpostia kim@kimcode.fi tai avaa ongelma GitHubin issues-osiossa.
