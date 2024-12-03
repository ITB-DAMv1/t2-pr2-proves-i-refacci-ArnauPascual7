# T2. PR2. Proves i refacció

Arnau Pascual

## Exercicis

### 1. Quines són les característiques i els escenaris d'ús de les metodologies àgils de desenvolupament de programari? Explica amb detall i posa un exemple.

#### Principis bàsics:
- **Satisfacció del client**: Mitjançant el lliurament anticipat i continu de programari valuós es busca mantenir el client satisfet.
- **Canvis de requisits**: Tots els canvis són benvinguts, si així el producte aportarà més valor per al negoci.
- **Lliuraments freqüents**: Es fan lliuraments del programari funcional tan freqüent com sigui possible.
- **Col·laboració**: Fomenten el treball en equip i la communicació entre : l'equip de desenvolupament i el grup responsable del negoci.
- **Confiança**: Els projectes són elavorats per individus motivats, en els quals cal confiar.
- **Communicació**: La communiicaió del negocis és cara a cara, i es prioritza sobre la documentació exhaustiva.
- **Progrés**: El programari en funcionament és la mesura principal del progrés.
- **Desenvolupament sostenible**: Tot l'equip ha de mantenir un ritme constat indefinidament.
- **Atenció a l'excel·lència**: Durant tot el procés es té en compte l'excel·lència tècnica i la qualitat del disseny.
- **Simplicitat**: Minimitzen la quantitat de treball no realitzat, per a centrar-se en l'essencial.
- **Autoorganització**: Un equip Autoorganitzat i multifuncional creen millors arquitectures, requisits i dissenys.
- **Adaptabilitat**: Permeten una ràpida adaptació a canvis, l'equip delibera regularment sobre la seva efectivitat i sobre com es pot millorar

#### Escenaris d'ús
Les metodologies ágils es podent utilitzar en projectes complexos, en entorns dinàmics, en el desenvolupament interactiu, en l'enfocament del client, en els lliuraments freqüents, en els projectes amb riscos, en equips multidisciplinaris, en la millora contínua, en la qulitat del producte i en la flexibilitat.

#### Exemple
Una empresa contracte a una altre empresa de desenvolupament d'aplicacions. L'empresa contractada col·laborarà amb l'empresa client per a fer la seva aplicació. L'empresa d'apliacions intentarà mostrar resultats, o parts fentes de l'aplicació al client per a mostrar com avança el projecte i que el client pugui fer peticions per a la seva aplicació. A partir de les peticions del client l'empresa d'aplicacions pot modificar i millorar el producte final per adaptar-se al client. Una de les metodologies àgils més habituals és la Scrum, podríen utilitzar aquesta per al projecte.

**Scrum**, és una metodologia àgil que tracte de dividir el treball en "*sprints*", cada un d'aquests sprints són perdiodes de 1 a 4 setmanes de treball, en el qual en cada sprint es planmifica la fenia a fer, i al final de cada un es fa una revisió del que s'ha fet. La metodologia Scrum, també es centra en desenvolupar les funcionalitats més importants primer, per a proporcionar un producte potencialment llançable al final de cada sprint.

---

### 2. Què són els dobles de prova? Explica amb detall els diferents tipus i posa un exemple d’ús per a una solució en C#.

Els dobles de prova són eines comúns en el testing de software, els test doubles fan referència a qualsevol cas en el que es remplaça un objecte de producció amb un altre amb l'objectiu de provar el codi. S'utilitzen per a simular el comportament d'una dependència d'una aplicació en un entorn de proves, sense tneir que dependre de la implemantació real d'aquesta dependència.

#### Tipus de dobles de prova:
- **Dummy**: S'utilitzen per quan necessitem que un objecte compleixi una firma de mètode o una interfície, però no tenim inteció d'utilitzar realment. Basicament, volem que compili.
- **Stub**: S'utilitzen per a simular el comportament d'una dependència en un entorn de proves. El seu propòsit és el de proporcinar valors concrets per a guiar el test cap a una determinada direcció.
- **Fake**: S'utilitzen per a simular el comportament i la interfície d'una dependència real.
- **Spy**: S'utilitzen per a registrar el comportament d'una dependència, per a poder verificar el seu funcionament.
- **Mock**: S'utilitzen al igual que els Spy per a verificar el comportament d'una dependència, però a diferència d'aquests el Mock, comprova els mètodes que s'han invocat, amb quina argument, quan s'han invocat i amb quina freqüencia s'ha fet. S'utilitzen principalment per comprovar el comportament del codi i que es fa de forma esperada.

#### Exemple

##### Dummy
    [TestMethod]
    public void EnviarEmail_AmbDestinatariDummy_NoLlancaExcepcio()
    {
        // Arrange
        var dummy = new object(); // Dummy
        var emailService = new EmailService();

        // Act & Assert
        Assert.DoesNotThrow(() => emailService.EnviarEmail("test@example.com", dummy));
    }

##### Stub
    [TestMethod]
    public void ObtindrePreu_AmbStubDeRepositori_RetornaPreuEsperat()
    {
        // Arrange
        var stubRepositori = new Mock<IProducteRepositori>();
        stubRepositori.Setup(r => r.ObtindrePreu(It.IsAny<int>())).Returns(100);
        var serveiPreus = new ServeiPreus(stubRepositori.Object);

        // Act
        var preu = serveiPreus.ObtindrePreu(1);

        // Assert
        Assert.AreEqual(100, preu);
    }

##### Fake
    [TestMethod]
    public void ObtenirUsuari_AmbFakeRepositori_RetornaUsuariCorrecte()
    {
        // Arrange
        var fakeRepositori = new FakeUsuariRepositori();
        fakeRepositori.AfegirUsuari(new Usuari { Id = 1, Nom = "Joan" });
        var serveiUsuaris = new ServeiUsuaris(fakeRepositori);

        // Act
        var usuari = serveiUsuaris.ObtenirUsuari(1);

        // Assert
        Assert.AreEqual("Joan", usuari.Nom);
    }

##### Spy
    [TestMethod]
    public void EnviarEmail_AmbSpy_VerificaQueElMetodeEsCridat()
    {
        // Arrange
        var spyEmailSender = new Mock<IEmailSender>();
        var serveiNotificacions = new ServeiNotificacions(spyEmailSender.Object);

        // Act
        serveiNotificacions.NotificarUsuari("user@example.com", "Missatge de prova");

        // Assert
        spyEmailSender.Verify(s => s.EnviarEmail("user@example.com", "Missatge de prova"), Times.Once());
    }

##### Mock
    [TestMethod]
    public void ProcessarComanda_AmbMockDePagament_VerificaComportament()
    {
        // Arrange
        var mockPagamentService = new Mock<IPagamentService>();
        mockPagamentService.Setup(s => s.ProcessarPagament(It.IsAny<decimal>())).Returns(true);
        var serveiComandes = new ServeiComandes(mockPagamentService.Object);

        // Act
        serveiComandes.ProcessarComanda(new Comanda { Total = 100 });

        // Assert
        mockPagamentService.Verify(s => s.ProcessarPagament(100), Times.Once());
        mockPagamentService.Verify(s => s.EnviarConfirmacio(), Times.Once());
    }

---

### 3. Què és CI/CD? Fes un vídeo explicant les característiques bàsiques, el seu flux de treball i un exemple pràctic d’integració amb GitHub d’una solució en C#.

CI/CD és la integració contínua de codi a un repositori múltiples vegades al dia. A trevés de l'entrega contínua (CI) de codi s'automatitza les integracions de codi, mentres que l'implemantació contínua (CD) entrega automàticament les versions finals.

#### Integració contínua (CI)

Consisteix en integrar tots els canvis de codi en la branca pricipal d'un repositori, per a provar automàticament cada canvi i iniciar automàticament una compilació. Amb l'integració contínua, els errors i problemes se seguretat es poden identificar amb més facilitat.

Al fusionar els canvis amb freqüencia minimitzem la possiblitat de conflictes en el codi. El process comença amb una validació del codi estàtic, en el que es verifica la qualitat del codi. Un cop superada, es comença amb les ritines autimatitzades, que empaqueten y compilen el codi per a realitzar proves automatitzades.

#### Entrega contínua (CD)

L'entrega contínua es complemanta emb l'integració contínua, per automatitzar el procés. Una vegada s'ha completat l'integració contínua entra l'entrega contínua, abans que el producte final estigui acabat, aquesta consisteix en mantenir els conjunts de canvis suficientment petits per a que cap actualització de la compilació principal pugui malmetre l'estat del producte final.

#### Flux de treball

El workflow es basa en l'anàlisis del repositiry, si un repository conté una aplicació Node.js, l'anàlisis prioritzarà mostrar el workflow realcionat a Node.

---

### 4. Aplica els patrons de refacció més habituals en el codi que trobaràs en aquest [enllaç](https://github.com/damvdev/programacio-entorns-i-processos/blob/main/tema_2/Activitats/T2.PR2/ExerciseFour.cs). Hauràs de:
- crear un projecte vinculat al teu repositori de la tasca
- crear una issue per cada tasca que s’hagi de dur a terme per aplicar els diferents patrons
- tancar les tasques mitjançant Visual Studio i les pull requests (PR)
- crear els tests unitaris per a validar el teu codi
- documentar els patrons que has aplicat i els criteris per a executar els casos de prova

#### Issues
- Tots els textos i missatges per l'usuari han d'estar dins de constants.
- Les variables s'han de declarar en la part superior del Main.
- Els valors d'input de l'usuari s'han de comprovar amb un try/catch.
- S'ha de crear un mètode per a l'input de l'usuari.
- S'ha de crear un mètode per a demanar l'alçada del rectangle.
- S'ha de crear un mètode per a demanar l'amplada del rectangle.
- S'ha de crear un mètode per a calcular l'area del rectangle.
- S'ha de crear un mètode per a demanar el radi del cercle.
- S'ha de crear un mètode per a calcular la circumferència del cercle.
- S'ha de crear un mètode per a imprimir un missatge segons el valor de l'area.
- S'ha d'afegir una funció per a reduïr el Main().
- S'han de crear funcions per a que ProgramCore() no realitzi més d'una funció.
- S'han d'eliminar els comentaris que són redundants.
- S'ha d'afegir Unit Testing a Ex4/Program.cs.

#### Casos de prova
He utilitzat dos casos de prova per a cada funció en el que un eren valors enters i l'altre valors decimals, per a comprovar el resultat de les funcions.

---

### 5. Defineix els casos de prova i implements els tests unitaris pel següent problema:
*La llibreria PersonaHelper ha estat creada per ajudar en l'anàlisi de dades personals. Proporciona mètodes per classificar l'edat d'una persona, comprovar si un nombre és parell, analitzar les característiques d'un nom, verificar la categoria d'un color, i determinar la preferència de personalitat d'acord amb el moment del dia. L'objectiu és testar aquests mètodes amb classes d'equivalència, valors límit i casos de prova per assegurar-ne el correcte funcionament.*

*Les restriccions són les següents:*
>- public int ClassifyAge(int age): edats vàlides [0-120]
>- public bool IsEven(int age): retorna si l’edat és parell o senar
>- public (bool IsShort, bool IsPalindrome) NameAnalyser(string name):
>   - < 5 caràcters: és un nom curt
>   - ≥ 5 caràcters: no és un nom curt
>   - retorna si el nom és palíndrom o no
>- public int VerifyColour(string colour):
>   - -1: invàlid
>   - 0: calmant [blau, verd]
>   - 1: exclusiu
>- public int PersonalityTest(string preference):
>   - “matí”: retorna 0 [personalitat Matinal]
>   - “nit”:  retorna 1 [personalitat Nocturna]
>   - qualsevol altre cas: retorna 2 [personalitat Imprevista]

En el mateix projecte que a l’exercici anterior, hauràs de:
- crear una issue per la tasca que s’ha de dur a terme per fer les proves
- tancar les tasques mitjançant Visual Studio i les pull requests (PR)
- crear els tests unitaris per a validar la [.dll](https://github.com/damvdev/programacio-entorns-i-processos/blob/main/tema_2/Activitats/T2.PR2/ExerciseFive.dll) fent servir el framework XUNit
- documentar els criteris per a executar els casos de prova i les incidències detectades (si s’escau)

*Nota: en aquest [enllaç](https://github.com/damvdev/programacio-entorns-i-processos/blob/main/tema_2/Activitats/T2.PR2/ExerciseFive.cs) trobeu la class library perquè us pugui ajudar a definir els test, però en el projecte de testing s’ha de fer servir la dll, no la class library.

#### Els tests estàn fets a partir de la .dll, però també tinc la Llibreria amb el codi del Exercici 5, però aquesta no està en dependències, en despendències només està la .dll

#### Issues
- Unit Testing per a ClassifyAge().
- Unit Testing per a IsEven().
- Unit Testing per a VerifyColour().
- Unit Testing per a PersonalityTest().

#### Casos de prova
- **ClassifyAge()**: Valors vàlids per l'edat, i segons el codi no ha valors invàlids, així que un cas de prova per a cada return de la funció. Per a comprovar l'edat dels nens, adults i gent gran.
- **IsEven()**: Valors parells per a que donin True i valors imparells per a que donin False.
- **VerifyColour()**: String buit per al primer return i strings amb "blau" i "verd" per al segon return, el restant amb qualsevol altre cosa que no sigui cap de les anteriors.
- **PersonalityTest()**: Strings amb "matí" i "nit" per al primer i segon return i qualsevol altre cosa per al return restant.

### 6. Què són els analitzadors de codi? Fes un vídeo explicant les característiques principals i mostra la configuració i funcionament de Sonarqube amb una solució teva en C#.  

L'anàlisis de codi és un procès de revisió de codi en el que es preten avaluar el codi. Aquesta evaluació tracte de buscar els problemes de funcionament del codi i preten millorar el seu funcionament.

#### Anàlisis estàtic

L'anàlisis estàtic es realitza sense la necessitat d'executar codi. Al no haver-se d'executar aquest anàlisis permet trobar errors en el codi molt abans.

##### Les eines d'anàlisis estàtic permet:
- **Millorar la qualitat del codi**, ja que poden identificar problemes abans de que el programa s'executi.
- **Aumenta la seguretat**, ja que poden detectar vulnerabilitats de seguretat bans de que puguin ser explotades.
- **Facilita la col·laboració**, ja que les eines ajuden a mantindre un estàndard de codificació comú.
- **Ahorren costos**, ja que poden identificar i solucionar problemes en etapes inicials del desenvolupament.

##### Les eines d'anàlisis estàtic

Les eines utilitzen regles i algoritmes per a trovar problemes dins del codi. Les regles van de detectar errors de sitàxis a identificar patrons de codi que no compleixen amb les millors pràctiques de programació.

Les eines escanegen el codi font i generen un informe que enumera tots els problemes trobats. Els informes proporcionen ionformació, com la ubicació exacte dels problemes en el codi.

#### Anàlisis dinàmic

L'anàlisis dinàmic es realitza mentre el codi s'està executant, el qual permet veure molts més errors que l'anàlisis estàtic no permet. Un exemple de anàlisis dinàmic són les proves de caixa negra i blanca.

#### SonarQube

SonarQube és una plataforma que proporciona un anàlisis estàtic del codi per a detectar problemes de qualitat i seguretat.

##### Algunes de les seves característiques més importants són:

- Admet molts dels llengutges de programació més populars.
- Realitza revisions automàtiques amb un anàlisis estàtic del codi estàtic.
- Facilita informes que ofreixen informació objectiva de la qulitat dels projectes.
- S'integra amb tota la cadena d'eines de DevOps.
- Es poden ampliar les seves funcionalitats a través de complements i extensións.

---

### 7. Indica les referències que has consultat (pàgines web, llibres, revistes,...), seguint el següent format:
Cal seguir la notació bibliogràfica següent:
>**Com citar una pàgina web:**
>
>Cognom, A., Cognom, B., i Cognom, C. (dia de mes de any). Títol de l'article de la pàgina web. Nom del lloc web. Recuperat el dia mes any de https://url.com
>
>**Com citar un llibre:**
>
>Cognom, A. i Cognom, B. (Any de publicació). Títol del llibre. (Número d'edició ed.). Editorial.

En el cas de consultar a una IA (chatGPT, Bard, …) cal escriure els prompts que has fet servir i la seva resposta.
>**📎 Quines són les figures més rellevants en el món de la programació?**
>
>Hi ha diverses figures rellevants en el món de la programació que han fet contribucions clau al desenvolupament de la informàtica i del software. Aquí en tens algunes de les més importants…

---

#### Bibliografia

##### Pàgines web

>Sense Autor. (darrera modificació: 25/9/2024, data de creació: 3/6/2007). Metodologia àgil. Viquipèdia. Recuperat el 26/11/2024 de https://ca.wikipedia.org/wiki/Metodologia_%C3%A0gil.

>Isabel Polo de la Llana i Jorge Fernández González. (Sense data). Metodologies àgils. PDF. Recuperat el 1/12/2024 de https://openaccess.uoc.edu/bitstream/10609/141366/1/Tecniques%20avanc¿ades%20de%20l'enginyeria%20de%20programari_Modul1_Metodologies%20agils.pdf

>Antonio Leiva. (5/1/2023). ¿Qué son los dobles de test?. DevExpert. Recuperat el 1/12/2024 de https://devexpert.io/dobles-test/

> Keyvan Akbary. (Sense data, però per els comentaris fa més de 10 anys). Test doubles. Kayvanakbary. Recuperat el 1/12/2024 de https://keyvanakbary.com/test-doubles/

> Sense Autor (Unity Technologies). (Sense data). ¿Qué es CI/CD?. Unity. Recuperat el dia 1/12/2024 de https://unity.com/es/topics/what-is-ci-cd

> Sense Autor (GitLab). (Sense data). ¿Qué es la CI/CD?. GitLab. Recuperat el dia 1/12/2024 de https://about.gitlab.com/es/topics/ci-cd/

> Brian Douglas. (2/2/2022). How to build a CI/CD pipeline with GitHub Actions in four simple steps. GitHub. Recuperat el dia 2/12/2024 de https://github.blog/enterprise-software/ci-cd/build-ci-cd-pipeline-github-actions-four-steps/

> Pulkit Agarwal. (17/12/2021). Getting started with GitHub Actions just got easier!. GitHub. Recuperat el dia 2/12/2024 de https://github.blog/news-insights/product-news/getting-started-with-github-actions-just-got-easier/

> Sense Autor (GitHub Docs). Quickstart for GitHub Actions. GitHub Docs. Recuperat el dia 2/12/2024 de https://docs.github.com/en/actions/writing-workflows/quickstart

> NeverTrust. (25/1/2018). Assets file project.assets.json not found. Run a NuGet package restore. StackOverflow. Recuperat el dia 2/12/2024 de https://stackoverflow.com/questions/48440223/assets-file-project-assets-json-not-found-run-a-nuget-package-restore

> 25 contribuïdors (Microsoft). (3/07/2024). Unit testing C# in .NET using dotnet test and xUnit. Microsoft Learn. Recuperat el dia 3/12/2024 de https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-dotnet-test

> Manuel Dávila. (12/6/2023). Introducción a xUnit: Una poderosa herramienta para Unit Testing en .NET. Dev. Recuperat el dia 3/12/2024 de https://dev.to/maadcode/introduccion-a-xunit-una-poderosa-herramienta-para-unit-testing-en-net-34b0

> Sense Autor. (3/4/????). Análisis dinámico de código vs análisis estático. Go4it Solutions. Recuperat el dia 2/12/2024 de https://go4it.solutions/es/blog/analisis-dinamico-de-codigo-vs-analisis-estatico

> Alberto Casero. (darrera modificació: 7/8/2024). ¿Qué son las herramientas de análisis estático del código?. KeepCoding. Recuperat el dia 2/12/2024 de https://keepcoding.io/blog/herramientas-de-analisis-estatico-del-codigo/

> Sentiro. (15/12/2021). Qué es SonarQube: Verifica y analiza la calidad de tu código. Sentiro. Recuperat el dia 2/12/2024 de https://sentrio.io/blog/que-es-sonarqube/

> Sonar. (fa 1 any). What is SonarQube?. Youtube. Recuperat el dia 3/12/2024 de https://www.youtube.com/watch?v=xeTwG9XFFTE&t=46s

> SonarQube Docs. (Sense data). GitHub integration. SonarQube Docs. Recuperat el dia 3/12/2024 de https://docs.sonarsource.com/sonarqube-server/9.8/devops-platform-integration/github-integration/

> DevOps Coach. (16/2/2024). How to Integrate SonarQube with GitHub Actions | Automate Code Scan using SonarQube in GitHub Action. Youtube. Recuperat el dia 3/12/2024 de https://www.youtube.com/watch?v=AYl3A3ac7bg

> DevOps Coach (14/2/2024). How to integrate SonarQube with GitHub Actions CICD Pipeine | SonarQube Integration with GitHub Actions| Automate Code Scan using SonarQube In GitHub Actions. Blogger (coachdevops). Recuperat el dia 3/12/2024 de https://www.coachdevops.com/2024/02/how-to-integrate-sonarqube-with-github.html

##### Consultes IA

>**Quines són les característiques de les metodologies àgils de desenvolupament de programari?**
>
>Les metodologies àgils de desenvolupament de programari es caracteritzen per:
>- Desenvolupament iteratiu i incremental: Es divideixen les tasques en petits increments amb planificació mínima, generalment en iteracions d'1 a 4 setmanes.
>- Adaptabilitat: Permeten una ràpida adaptació a canvis en els requisits i prioritats del projecte.
Col·laboració: Fomenten el treball en equip multidisciplinari i la comunicació constant entre desenvolupadors, clients i usuaris finals.
>- Lliurament ràpid: Prioritzen el lliurament primerenc i continu de programari funcional.
>- Millora contínua: Els equips reflexionen regularment sobre com ser més efectius i ajusten el seu comportament en conseqüència.
>- Enfocament en la qualitat: Utilitzen tècniques com la integració contínua, proves unitàries automatitzades i programació en parelles per millorar la qualitat del programari.
>- Simplicitat: Busquen maximitzar la quantitat de treball no realitzat, centrant-se en l'essencial.
>- Autoorganització: Els equips són autoorganitzats i multifuncionals.
>- Comunicació directa: Prioritzen la comunicació cara a cara sobre la documentació exhaustiva.
>- Flexibilitat: Responen al canvi en lloc de seguir estrictament un pla.
Aquestes característiques permeten a les metodologies àgils minimitzar riscos, millorar la qualitat del programari i adaptar-se ràpidament a les necessitats canviants del projecte i del client.

>**Quins són els escenaris d'ús de les metodologies àgils de desenvolupament de programari?**
>
>Les metodologies àgils de desenvolupament de programari són especialment adequades per a certs escenaris:
>- Projectes complexos: S'utilitzen en sistemes i desenvolupaments complexos on és difícil fer prediccions acurades del temps necessari de desenvolupament1.
>- Entorns dinàmics: Són ideals per a projectes amb requisits canviants o poc definits inicialment1.
>- Desenvolupament iteratiu: S'apliquen en projectes que es poden dividir en petits increments amb planificació mínima, típicament en iteracions d'una a quatre setmanes1.
>- Enfocament en el client: Són adequades quan es busca una col·laboració estreta amb el client i una resposta ràpida als canvis en els requisits1.
>- Lliuraments freqüents: S'utilitzen quan es vol mostrar el producte treballat a les parts interessades al final de cada iteració1.
>- Projectes amb riscos: Són efectives per minimitzar grans riscos i permetre que el producte s'adapti ràpidament1.
>- Equips multidisciplinaris: S'apliquen en projectes que requereixen equips autoorganitzats i multifuncionals1.
>- Millora contínua: Són ideals per a projectes que busquen una millora constant del procés i del producte1.
>- Qualitat del producte: S'utilitzen quan es vol implementar tècniques com la integració contínua, proves unitàries automatitzades i programació en parelles per millorar la qualitat del programari1.
>- Flexibilitat: Són adequades per a projectes que necessiten respondre al canvi en lloc de seguir estrictament un pla tancat1.

>**De que tracte le metodologia Scrum?**
>
>Scrum és un marc de treball àgil per a la gestió de projectes, especialment utilitzat en el desenvolupament de programari. Les seves principals característiques són:
>- Desenvolupament iteratiu i incremental: El treball es divideix en sprints, que són períodes curts d'1 a 4 setmanes12.
>- Equip autoorganitzat: Consta d'un Product Owner, un Scrum Master i els Desenvolupadors, que treballen junts per assolir els objectius del sprint34.
>- Artefactes: Utilitza tres artefactes principals: el product backlog, el sprint backlog i l'increment1.
Esdeveniments: Inclou esdeveniments com la planificació del sprint, el daily scrum, la revisió del sprint i la retrospectiva12.
>- Enfocament empíric: Es basa en la transparència, la inspecció i l'adaptació contínues4.
>- Priorització: Es centra en desenvolupar les funcionalitats més importants primer3.
>- Flexibilitat: Permet adaptar-se ràpidament als canvis en els requisits3.
>- Col·laboració: Fomenta la comunicació constant i la col·laboració entre els membres de l'equip i els stakeholders34.
>- Millora contínua: Utilitza retrospectives per reflexionar i millorar constantment el procés i el producte14.
>- Entregues freqüents: Busca proporcionar un producte potencialment llançable al final de cada sprint23.

>**Dona'm un exemple de cada un dels 5 tipus de dobles de prova (Dummy, Stub, Fake, Spy i Mock) per a una solució en C#**
>
>Aquí teniu exemples dels cinc tipus de dobles de prova en C# utilitzant el marc de proves NUnit i la biblioteca de simulació Moq:
>- Dummy:
>
>       [Test]
>       public void EnviarEmail_AmbDestinatariDummy_NoLlancaExcepcio()
>       {
>           // Arrange
>           var dummy = new object(); // Dummy
>           var emailService = new EmailService();
>
>           // Act & Assert
>           Assert.DoesNotThrow(() => emailService.EnviarEmail("test@example.com", dummy));
>       }
>- Stub:
>
>        [Test]
>        public void ObtindrePreu_AmbStubDeRepositori_RetornaPreuEsperat()
>        {
>            // Arrange
>            var stubRepositori = new Mock<IProducteRepositori>();
>            stubRepositori.Setup(r => r.ObtindrePreu(It.IsAny<int>())).Returns(100);
>            var serveiPreus = new ServeiPreus(stubRepositori.Object);
>
>            // Act
>            var preu = serveiPreus.ObtindrePreu(1);
>
>            // Assert
>            Assert.AreEqual(100, preu);
>        }
>- Fake:
>
>        public class FakeUsuariRepositori : IUsuariRepositori
>        {
>            private List<Usuari> _usuaris = new List<Usuari>();
>
>            public void AfegirUsuari(Usuari usuari)
>            {
>                _usuaris.Add(usuari);
>            }
>
>            public Usuari ObtenirUsuari(int id)
>            {
>                return _usuaris.FirstOrDefault(u => u.Id == id);
>            }
>        }
>
>        [Test]
>        public void ObtenirUsuari_AmbFakeRepositori_RetornaUsuariCorrecte()
>        {
>            // Arrange
>            var fakeRepositori = new FakeUsuariRepositori();
>            fakeRepositori.AfegirUsuari(new Usuari { Id = 1, Nom = "Joan" });
>            var serveiUsuaris = new ServeiUsuaris(fakeRepositori);
>
>            // Act
>            var usuari = serveiUsuaris.ObtenirUsuari(1);
>
>            // Assert
>            Assert.AreEqual("Joan", usuari.Nom);
>        }
>- Spy:
>        [Test]
>        public void EnviarEmail_AmbSpy_VerificaQueElMetodeEsCridat()
>        {
>            // Arrange
>            var spyEmailSender = new Mock<IEmailSender>();
>            var serveiNotificacions = new ServeiNotificacions(spyEmailSender.Object);
>
>            // Act
>            serveiNotificacions.NotificarUsuari("user@example.com", "Missatge de prova");
>
>            // Assert
>            spyEmailSender.Verify(s => s.EnviarEmail("user@example.com", "Missatge de prova"), Times.Once());
>        }
>- Mock:
>        [Test]
>        public void ProcessarComanda_AmbMockDePagament_VerificaComportament()
>        {
>            // Arrange
>            var mockPagamentService = new Mock<IPagamentService>();
>            mockPagamentService.Setup(s => s.ProcessarPagament(It.IsAny<decimal>())).Returns(true);
>            var serveiComandes = new ServeiComandes(mockPagamentService.Object);
>
>            // Act
>            serveiComandes.ProcessarComanda(new Comanda { Total = 100 });
>
>            // Assert
>            mockPagamentService.Verify(s => s.ProcessarPagament(100), Times.Once());
>            mockPagamentService.Verify(s => s.EnviarConfirmacio(), Times.Once());
>        }
>.

> **Que són els analitzadors de codi?**
>
>Els analitzadors de codi són eines que examinen el codi font d'un programa informàtic per detectar possibles errors, vulnerabilitats o problemes de qualitat. Aquestes eines realitzen una anàlisi estàtica del codi sense executar-lo, permetent als desenvolupadors identificar i corregir problemes potencials abans que el programa s'executi.
Les principals característiques dels analitzadors de codi inclouen:
>- Detecció d'errors: Identifiquen errors de sintaxi, variables no utilitzades, problemes de tipatge, entre altres.
>- Anàlisi de seguretat: Busquen vulnerabilitats potencials com injeccions SQL o desbordaments de memòria.
>- Millora de la qualitat: Avaluen la complexitat del codi, la duplicació i altres mètriques de qualitat.
>- Compliment d'estàndards: Verifiquen que el codi segueixi les convencions i estils de codificació establerts.
>- Integració amb CI/CD: Molts analitzadors de codi s'integren en pipelines de CI/CD per automatitzar l'anàlisi durant el procés de desenvolupament.