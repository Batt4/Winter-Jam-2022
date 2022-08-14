using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace WinterJam2022.Scripts.Presentation
{
    public class CardView : MonoBehaviour
    {
        [SerializeField] EventManager eventManager;
        [SerializeField] TextMeshProUGUI text;
        [SerializeField] TextMeshProUGUI points;
        [SerializeField] TextMeshProUGUI special;

        List<Word> availableWords;

        event EventHandler OnCardPlayed;

        Card card;

        readonly List<string> wordsVerb = new List<string>()
        {
            "Abrir",
            "Rapeo"
            "Amar",
            "Asesinar",
            "Bastar",
            "Callar",
            "Cantar",
            "Cerrar",
            "Comer",
            "Conseguir",
            "Coser",
            "Culpar",
            "Decir",
            "Destruir",
            "Durar",
            "Encontrar",
            "Esconder",
            "Estar",
            "Faltar",
            "Gustar",
            "Intentar",
            "Lanzar",
            "Llamar",
            "Luchar",
            "Mentir",
            "Necesitar",
            "Ofrecer",
            "Parar",
            "Pelear",
            "Perdonar",
            "Preferir",
            "Prometer",
            "Recibir",
            "Repetir",
            "Salir",
            "Sentir",
            "So�ar",
            "Tener",
            "Trabajar",
            "Vender",
            "Vivir",
            "Acabar",
            "Andar",
            "Atacar",
            "Ba�ar",
            "Calmar",
            "Cazar",
            "Citar",
            "Comparar",
            "Contar",
            "Costar",
            "Dar",
            "Dejar",
            "Disculpar",
            "Elegir",
            "Ense�ar",
            "Escribir",
            "Estudiar",
            "Forzar",
            "Haber",
            "Ir",
            "Largar",
            "Llegar",
            "Mandar",
            "Mirar",
            "Negociar",
            "Olvidar",
            "Parecer",
            "Peligrar",
            "Permitir",
            "Preguntar",
            "Pulsar",
            "Reconocer",
            "Responder",
            "Saltar",
            "Ser",
            "Suceder",
            "Terminar",
            "Traer",
            "Venir",
            "Volver",
            "Acercar",
            "Apoyar",
            "Ayudar",
            "Beber",
            "Cambiar",
            "Cenar",
            "Cocinar",
            "Comprar",
            "Continuar",
            "Crear",
            "Da�ar",
            "Descansar",
            "Divertir",
            "Empezar",
            "Entender",
            "Escuchar",
            "Existir",
            "Funcionar",
            "Hablar",
            "Jugar",
            "Lavar",
            "Llenar",
            "Matar",
            "Morir",
            "Nombrar",
            "Orar",
            "Partir",
            "Penar",
            "Pisar",
            "Preocupar",
            "Quedar",
            "Recordar",
            "Re�r",
            "Salvar",
            "Significar",
            "Suponer",
            "Tirar",
            "Tratar",
            "Ver",
            "Aconsejar",
            "Aprender",
            "Bailar",
            "Buscar",
            "Caminar",
            "Centrar",
            "Coger",
            "Conducir",
            "Correr",
            "Creer",
            "Deber",
            "Describir",
            "Doler",
            "Empujar",
            "Entrar",
            "Esperar",
            "Explicar",
            "Ganar",
            "Hacer",
            "Jurar",
            "Leer",
            "Llevar",
            "Mejor",
            "Mostrar",
            "Ocurrir",
            "O�r",
            "Pasar",
            "Pensar",
            "Poder",
            "Preparar",
            "Quemar",
            "Regalar",
            "Saber",
            "Seguir",
            "Sonar",
            "Tardar",
            "Tocar",
            "Usar",
            "Viajar",
            "Acordar",
            "Armar",
            "Bajar",
            "Caer",
            "Campar",
            "Cercar",
            "Comenzar",
            "Conocer",
            "Cortar",
            "Cuidar",
            "Decidir",
            "Desear",
            "Dormir",
            "Encantar",
            "Equipar",
            "Esposar",
            "Extra�ar",
            "Gritar",
            "Importar",
            "Lamentar",
            "Limpiar",
            "Llorar",
            "Mejorar",
            "Mover",
            "Odiar",
            "Pagar",
            "Pelar",
            "Perder",
            "Poner",
            "Probar",
            "Querer",
            "Regresar",
            "Sacar",
            "Sentar",
            "Sonre�r",
            "Temer",
            "Tomar",
            "Valer",
            "Visitar"
        };


        void Start()
        {
            availableWords = new List<Word>
            {
                new Word(WordType.SUBJECT, "Crema", Random.Range(1, 15), "ma"),
                new Word(WordType.SUBJECT, "Rapero", Random.Range(1, 15), "ro"),
                new Word(WordType.SUBJECT, "Explosi�n", Random.Range(1, 15), "si�n"),
                new Word(WordType.SUBJECT, "Navaja", Random.Range(1, 15), "ja"),
                new Word(WordType.SUBJECT, "L�piz", Random.Range(1, 15), "piz"),
                new Word(WordType.SUBJECT, "Embarcaci�n", Random.Range(1, 15), "ci�n"),
                new Word(WordType.SUBJECT, "Ventana", Random.Range(1, 15), "na"),
                new Word(WordType.SUBJECT, "Universidad", Random.Range(1, 15), "dad"),
                new Word(WordType.SUBJECT, "Llaves", Random.Range(1, 15), "ves"),
                new Word(WordType.SUBJECT, "Pap�", Random.Range(1, 15), "p�"),
                new Word(WordType.SUBJECT, "Catre", Random.Range(1, 15), "tre"),
                new Word(WordType.SUBJECT, "Escuela", Random.Range(1, 15), "la"),
                new Word(WordType.SUBJECT, "Codo", Random.Range(1, 15), "do"),
                new Word(WordType.SUBJECT, "Mapa", Random.Range(1, 15), "pa"),
                new Word(WordType.SUBJECT, "Lima", Random.Range(1, 15), "ma"),
                new Word(WordType.SUBJECT, "Edificio", Random.Range(1, 15), "cio"),
                new Word(WordType.SUBJECT, "Hojas", Random.Range(1, 15), "jas"),
                new Word(WordType.SUBJECT, "Granizo", Random.Range(1, 15), "zo"),
                new Word(WordType.SUBJECT, "Mano", Random.Range(1, 15), "no"),
                new Word(WordType.SUBJECT, "M�sica", Random.Range(1, 15), "ca"),
                new Word(WordType.SUBJECT, "Habitaci�n", Random.Range(1, 15), "ci�n"),
                new Word(WordType.SUBJECT, "Abuelo", Random.Range(1, 15), "lo"),
                new Word(WordType.SUBJECT, "Templo", Random.Range(1, 15), "lo"),
                new Word(WordType.SUBJECT, "Plato", Random.Range(1, 15), "to"),
                new Word(WordType.SUBJECT, "Botella", Random.Range(1, 15), "lla"),
                new Word(WordType.SUBJECT, "Casa", Random.Range(1, 15), "sa"),
                new Word(WordType.SUBJECT, "Planeta", Random.Range(1, 15), "ta"),
                new Word(WordType.SUBJECT, "Metal", Random.Range(1, 15), "tal"),
                new Word(WordType.SUBJECT, "Mono", Random.Range(1, 15), "no"),
                new Word(WordType.SUBJECT, "Petr�leo", Random.Range(1, 15), "leo"),
                new Word(WordType.SUBJECT, "Debate", Random.Range(1, 15), "te"),
                new Word(WordType.SUBJECT, "Ruido", Random.Range(1, 15), "do"),
                new Word(WordType.SUBJECT, "Herramienta", Random.Range(1, 15), "ta"),
                new Word(WordType.SUBJECT, "Anteojos", Random.Range(1, 15), "jos"),
                new Word(WordType.SUBJECT, "Living", Random.Range(1, 15), "ving"),
                new Word(WordType.SUBJECT, "Zapato", Random.Range(1, 15), "to"),
                new Word(WordType.SUBJECT, "Ojo", Random.Range(1, 15), "jo"),
                new Word(WordType.SUBJECT, "Diente", Random.Range(1, 15), "te"),
                new Word(WordType.SUBJECT, "Buzo", Random.Range(1, 15), "zo"),
                new Word(WordType.SUBJECT, "Puerta", Random.Range(1, 15), "ta"),
                new Word(WordType.SUBJECT, "Ensalada", Random.Range(1, 15), "da"),
                new Word(WordType.SUBJECT, "Candidato", Random.Range(1, 15), "to"),
                new Word(WordType.SUBJECT, "Diarios", Random.Range(1, 15), "rios"),
                new Word(WordType.SUBJECT, "Hierro", Random.Range(1, 15), "rro"),
                new Word(WordType.SUBJECT, "Barco", Random.Range(1, 15), "co"),
                new Word(WordType.SUBJECT, "Tecla", Random.Range(1, 15), "cla"),
                new Word(WordType.SUBJECT, "Departamento", Random.Range(1, 15), "to"),
                new Word(WordType.SUBJECT, "Hipop�tamo", Random.Range(1, 15), "mo"),
                new Word(WordType.SUBJECT, "�rbol", Random.Range(1, 15), "bol"),
                new Word(WordType.SUBJECT, "Discurso", Random.Range(1, 15), "so"),
                new Word(WordType.SUBJECT, "R�cula", Random.Range(1, 15), "la"),
                new Word(WordType.SUBJECT, "Lentejas", Random.Range(1, 15), "jas"),
                new Word(WordType.SUBJECT, "Reloj", Random.Range(1, 15), "loj"),
                new Word(WordType.SUBJECT, "Desodorante", Random.Range(1, 15), "te"),
                new Word(WordType.SUBJECT, "Monta�as", Random.Range(1, 15), "�as"),
                new Word(WordType.SUBJECT, "Partido", Random.Range(1, 15), "do"),
                new Word(WordType.SUBJECT, "Fiesta", Random.Range(1, 15), "ta"),
                new Word(WordType.SUBJECT, "Caf�", Random.Range(1, 15), "f�"),
                new Word(WordType.SUBJECT, "Guitarra", Random.Range(1, 15), "rra"),
                new Word(WordType.SUBJECT, "Martillo", Random.Range(1, 15), "llo"),
                new Word(WordType.SUBJECT, "Lapicera", Random.Range(1, 15), "ra"),
                new Word(WordType.SUBJECT, "Letra", Random.Range(1, 15), "tra"),
                new Word(WordType.SUBJECT, "Librer�a", Random.Range(1, 15), "a"),
                new Word(WordType.SUBJECT, "Rueda", Random.Range(1, 15), "da"),
                new Word(WordType.SUBJECT, "Camisa", Random.Range(1, 15), "sa"),
                new Word(WordType.SUBJECT, "Sill�n", Random.Range(1, 15), "llon"),
                new Word(WordType.SUBJECT, "Teclado", Random.Range(1, 15), "do"),
                new Word(WordType.SUBJECT, "Pantalla", Random.Range(1, 15), "lla"),
                new Word(WordType.SUBJECT, "Tenedor", Random.Range(1, 15), "dor"),
                new Word(WordType.SUBJECT, "Agua", Random.Range(1, 15), "gua"),
                new Word(WordType.SUBJECT, "Cohete", Random.Range(1, 15), "te"),
                new Word(WordType.SUBJECT, "C�sped", Random.Range(1, 15), "ped"),
                new Word(WordType.SUBJECT, "Parlante", Random.Range(1, 15), "te"),
                new Word(WordType.SUBJECT, "Monitor", Random.Range(1, 15), "tor"),
                new Word(WordType.SUBJECT, "Hombre", Random.Range(1, 15), "bre"),
                new Word(WordType.SUBJECT, "Velero", Random.Range(1, 15), "ro"),
                new Word(WordType.SUBJECT, "Palo", Random.Range(1, 15), "lo"),
                new Word(WordType.SUBJECT, "Lentes", Random.Range(1, 15), "tes"),
                new Word(WordType.SUBJECT, "Nube", Random.Range(1, 15), "be"),
                new Word(WordType.SUBJECT, "Castillo", Random.Range(1, 15), "llo"),
                new Word(WordType.SUBJECT, "Libro", Random.Range(1, 15), "bro"),
                new Word(WordType.SUBJECT, "Televisor", Random.Range(1, 15), "sor"),
                new Word(WordType.SUBJECT, "Tel�fono", Random.Range(1, 15), "no"),
                new Word(WordType.SUBJECT, "Remera", Random.Range(1, 15), "ra"),
                new Word(WordType.SUBJECT, "Percha", Random.Range(1, 15), "cha"),
                new Word(WordType.SUBJECT, "Anillo", Random.Range(1, 15), "llo"),
                new Word(WordType.SUBJECT, "Pared", Random.Range(1, 15), "ed"),
                new Word(WordType.SUBJECT, "Cartas", Random.Range(1, 15), "tas"),
                new Word(WordType.SUBJECT, "Impresora", Random.Range(1, 15), "ra"),
                new Word(WordType.SUBJECT, "Luces", Random.Range(1, 15), "ces"),
                new Word(WordType.SUBJECT, "Bomba", Random.Range(1, 15), "ba"),
                new Word(WordType.SUBJECT, "Corbata", Random.Range(1, 15), "ta"),
                new Word(WordType.SUBJECT, "Planta", Random.Range(1, 15), "ta"),
                new Word(WordType.SUBJECT, "Oficina", Random.Range(1, 15), "na"),
                new Word(WordType.SUBJECT, "T�o", Random.Range(1, 15), "T�o"),
                new Word(WordType.SUBJECT, "Pradera", Random.Range(1, 15), "ra"),
                new Word(WordType.SUBJECT, "Deporte", Random.Range(1, 15), "te"),
                new Word(WordType.SUBJECT, "Fotograf�a", Random.Range(1, 15), "fia"),
                new Word(WordType.SUBJECT, "Refugio", Random.Range(1, 15), "gio"),
                new Word(WordType.SUBJECT, "Carne", Random.Range(1, 15), "ne"),
                new Word(WordType.SUBJECT, "Humedad", Random.Range(1, 15), "dad"),
                new Word(WordType.SUBJECT, "Celular", Random.Range(1, 15), "lar"),
                new Word(WordType.SUBJECT, "Sof�", Random.Range(1, 15), "fa"),
                new Word(WordType.SUBJECT, "Mesada", Random.Range(1, 15), "da"),
                new Word(WordType.SUBJECT, "Auto", Random.Range(1, 15), "to"),
                new Word(WordType.SUBJECT, "Famoso", Random.Range(1, 15), "so"),
                new Word(WordType.SUBJECT, "Piso", Random.Range(1, 15), "so"),
                new Word(WordType.SUBJECT, "Diputado", Random.Range(1, 15), "do"),
                new Word(WordType.SUBJECT, "Candado", Random.Range(1, 15), "do"),
                new Word(WordType.SUBJECT, "Computadora", Random.Range(1, 15), "ra"),
                new Word(WordType.SUBJECT, "Cuadro", Random.Range(1, 15), "dro"),
                new Word(WordType.SUBJECT, "Teatro", Random.Range(1, 15), "tro"),
                new Word(WordType.SUBJECT, "Bala", Random.Range(1, 15), "la"),
                new Word(WordType.SUBJECT, "Estrella", Random.Range(1, 15), "lla"),
                new Word(WordType.SUBJECT, "Pl�stico", Random.Range(1, 15), "co"),
                new Word(WordType.SUBJECT, "Libros", Random.Range(1, 15), "bros"),
                new Word(WordType.SUBJECT, "Aluminio", Random.Range(1, 15), "nio"),
                new Word(WordType.SUBJECT, "Agujeta", Random.Range(1, 15), "ta"),
                new Word(WordType.SUBJECT, "Sonido", Random.Range(1, 15), "do"),
                new Word(WordType.SUBJECT, "Perro", Random.Range(1, 15), "rro"),
                new Word(WordType.SUBJECT, "Pelo", Random.Range(1, 15), "lo"),
                new Word(WordType.SUBJECT, "Felicidad", Random.Range(1, 15), "dad"),
                new Word(WordType.SUBJECT, "Servilleta", Random.Range(1, 15), "ta"),
                new Word(WordType.SUBJECT, "Sol", Random.Range(1, 15), "sol"),
                new Word(WordType.SUBJECT, "Estad�stica", Random.Range(1, 15), "ca"),
                new Word(WordType.SUBJECT, "Mensaje", Random.Range(1, 15), "je"),
                new Word(WordType.SUBJECT, "Rey", Random.Range(1, 15), "rey"),
                new Word(WordType.SUBJECT, "Presidencia", Random.Range(1, 15), "cia"),
                new Word(WordType.SUBJECT, "Colegio", Random.Range(1, 15), "gio"),
                new Word(WordType.SUBJECT, "L�mpara", Random.Range(1, 15), "ra"),
                new Word(WordType.SUBJECT, "Flor", Random.Range(1, 15), "flor"),
                new Word(WordType.SUBJECT, "Tornillo", Random.Range(1, 15), "llo"),
                new Word(WordType.SUBJECT, "Abuela", Random.Range(1, 15), "la"),
                new Word(WordType.SUBJECT, "Sat�lite", Random.Range(1, 15), "te"),
                new Word(WordType.SUBJECT, "Bol�grafo", Random.Range(1, 15), "fo"),
                new Word(WordType.SUBJECT, "Gobierno", Random.Range(1, 15), "no"),
                new Word(WordType.SUBJECT, "Enano", Random.Range(1, 15), "no"),
                new Word(WordType.SUBJECT, "Persona", Random.Range(1, 15), "na"),
                new Word(WordType.SUBJECT, "Guantes", Random.Range(1, 15), "tes"),
                new Word(WordType.SUBJECT, "Proyector", Random.Range(1, 15), "tor"),
                new Word(WordType.SUBJECT, "Muela", Random.Range(1, 15), "la"),
                new Word(WordType.SUBJECT, "Remate", Random.Range(1, 15), "te"),
                new Word(WordType.SUBJECT, "Cuaderno", Random.Range(1, 15), "no"),
                new Word(WordType.SUBJECT, "Taladro", Random.Range(1, 15), "dro"),
                new Word(WordType.SUBJECT, "Chocolate", Random.Range(1, 15), "te"),
                new Word(WordType.SUBJECT, "Caramelos", Random.Range(1, 15), "los"),
                new Word(WordType.SUBJECT, "Angustia", Random.Range(1, 15), "tia"),
                new Word(WordType.SUBJECT, "Lluvia", Random.Range(1, 15), "via"),
                new Word(WordType.SUBJECT, "Peri�dico", Random.Range(1, 15), "co"),
                new Word(WordType.SUBJECT, "Chupet�n", Random.Range(1, 15), "tin"),
                new Word(WordType.SUBJECT, "Persiana", Random.Range(1, 15), "na"),
                new Word(WordType.SUBJECT, "Silla", Random.Range(1, 15), "lla"),
                new Word(WordType.SUBJECT, "Zool�gico", Random.Range(1, 15), "co"),
                new Word(WordType.SUBJECT, "Recipiente", Random.Range(1, 15), "te"),
                new Word(WordType.SUBJECT, "Ave", Random.Range(1, 15), "ve"),
                new Word(WordType.SUBJECT, "Pantal�n", Random.Range(1, 15), "lon"),
                new Word(WordType.SUBJECT, "Nieve", Random.Range(1, 15), "ve"),
                new Word(WordType.SUBJECT, "Pistola", Random.Range(1, 15), "lo"),
                new Word(WordType.SUBJECT, "Tristeza", Random.Range(1, 15), "za"),
                new Word(WordType.SUBJECT, "Cama", Random.Range(1, 15), "ma"),
                new Word(WordType.SUBJECT, "Campera", Random.Range(1, 15), "ra"),
                new Word(WordType.SUBJECT, "Cintur�n", Random.Range(1, 15), "ron"),
                new Word(WordType.SUBJECT, "Madera", Random.Range(1, 15), "ra"),
                new Word(WordType.SUBJECT, "Malet�n", Random.Range(1, 15), "tin"),
                new Word(WordType.SUBJECT, "Cuchillo", Random.Range(1, 15), "llo"),
                new Word(WordType.SUBJECT, "Luz", Random.Range(1, 15), "luz"),
                new Word(WordType.SUBJECT, "Radio", Random.Range(1, 15), "dio"),
                new Word(WordType.SUBJECT, "Calor", Random.Range(1, 15), "lor"),
                new Word(WordType.SUBJECT, "Bife", Random.Range(1, 15), "fe"),
                new Word(WordType.SUBJECT, "Auriculares", Random.Range(1, 15), "res"),

                new Word(WordType.ADJECTIVE, "Salado", Random.Range(1, 15), "do"),
                new Word(WordType.ADJECTIVE, "Dulce", Random.Range(1, 15), "ce"),
                new Word(WordType.ADJECTIVE, "Amargo", Random.Range(1, 15), "go"),
                new Word(WordType.ADJECTIVE, "�cido", Random.Range(1, 15), "do"),
                new Word(WordType.ADJECTIVE, "Rojo", Random.Range(1, 15), "jo"),
                new Word(WordType.ADJECTIVE, "Verde", Random.Range(1, 15), "de"),
                new Word(WordType.ADJECTIVE, "Rubio", Random.Range(1, 15), "bio"),
                new Word(WordType.ADJECTIVE, "Fuerte", Random.Range(1, 15), "te"),
                new Word(WordType.ADJECTIVE, "D�bil", Random.Range(1, 15), "bil"),
                new Word(WordType.ADJECTIVE, "Flexible", Random.Range(1, 15), "ble"),
                new Word(WordType.ADJECTIVE, "Tostado", Random.Range(1, 15), "do"),
                new Word(WordType.ADJECTIVE, "Ronco", Random.Range(1, 15), "co"),
                new Word(WordType.ADJECTIVE, "N�tido", Random.Range(1, 15), "do"),
                new Word(WordType.ADJECTIVE, "�spero", Random.Range(1, 15), "ro"),
                new Word(WordType.ADJECTIVE, "Suave", Random.Range(1, 15), "ve"),
                new Word(WordType.ADJECTIVE, "Rugoso", Random.Range(1, 15), "so"),
                new Word(WordType.ADJECTIVE, "Esponjoso", Random.Range(1, 15), "so"),
                new Word(WordType.ADJECTIVE, "Flojo", Random.Range(1, 15), "jo"),
                new Word(WordType.ADJECTIVE, "Redondo", Random.Range(1, 15), "do"),
                new Word(WordType.ADJECTIVE, "Cuadrado", Random.Range(1, 15), "do"),
                new Word(WordType.ADJECTIVE, "Universitario", Random.Range(1, 15), "rio"),
                new Word(WordType.ADJECTIVE, "Institucional", Random.Range(1, 15), "nal"),
                new Word(WordType.ADJECTIVE, "Art�stico", Random.Range(1, 15), "co"),
                new Word(WordType.ADJECTIVE, "Religioso", Random.Range(1, 15), "so"),
                new Word(WordType.ADJECTIVE, "Cultural", Random.Range(1, 15), "ral"),
                new Word(WordType.ADJECTIVE, "Estructural", Random.Range(1, 15), "ral"),
                new Word(WordType.ADJECTIVE, "Policial", Random.Range(1, 15), "al"),
                new Word(WordType.ADJECTIVE, "Mensual", Random.Range(1, 15), "al"),
                new Word(WordType.ADJECTIVE, "Diario", Random.Range(1, 15), "io"),
                new Word(WordType.ADJECTIVE, "Solar", Random.Range(1, 15), "ar"),
                new Word(WordType.ADJECTIVE, "Militar", Random.Range(1, 15), "ar"),
                new Word(WordType.ADJECTIVE, "Laboral", Random.Range(1, 15), "al"),
                new Word(WordType.ADJECTIVE, "Mercantil", Random.Range(1, 15), "il"),
                new Word(WordType.ADJECTIVE, "Vanguardista", Random.Range(1, 15), "ta"),
                new Word(WordType.ADJECTIVE, "Dental", Random.Range(1, 15), "al"),
                new Word(WordType.ADJECTIVE, "Quir�rgico", Random.Range(1, 15), "co"),
                new Word(WordType.ADJECTIVE, "Primer", Random.Range(1, 15), "er"),
                new Word(WordType.ADJECTIVE, "Grande", Random.Range(1, 15), "de"),
                new Word(WordType.ADJECTIVE, "Peque�o", Random.Range(1, 15), "�o"),
                new Word(WordType.ADJECTIVE, "Diminuto", Random.Range(1, 15), "to"),
                new Word(WordType.ADJECTIVE, "Seco", Random.Range(1, 15), "so"),
                new Word(WordType.ADJECTIVE, "Caro", Random.Range(1, 15), "ro"),
                new Word(WordType.ADJECTIVE, "Inteligente", Random.Range(1, 15), "te"),
                new Word(WordType.ADJECTIVE, "Divertido", Random.Range(1, 15), "do"),
                new Word(WordType.ADJECTIVE, "Fiel", Random.Range(1, 15), "el"),
                new Word(WordType.ADJECTIVE, "Agradable", Random.Range(1, 15), "ble"),
                new Word(WordType.ADJECTIVE, "Sucio", Random.Range(1, 15), "io"),
                new Word(WordType.ADJECTIVE, "Limpio", Random.Range(1, 15), "io"),
                new Word(WordType.ADJECTIVE, "Amable", Random.Range(1, 15), "ble"),
                new Word(WordType.ADJECTIVE, "Nuevo", Random.Range(1, 15), "vo"),
                new Word(WordType.ADJECTIVE, "Valiente", Random.Range(1, 15), "te"),
                new Word(WordType.ADJECTIVE, "Hermoso", Random.Range(1, 15), "so"),
                new Word(WordType.ADJECTIVE, "Largo", Random.Range(1, 15), "go"),
                new Word(WordType.ADJECTIVE, "Cruel", Random.Range(1, 15), "el"),
                new Word(WordType.ADJECTIVE, "Perfecto", Random.Range(1, 15), "to"),
                new Word(WordType.ADJECTIVE, "Culto", Random.Range(1, 15), "to"),
                new Word(WordType.ADJECTIVE, "Ancho", Random.Range(1, 15), "cho"),
                new Word(WordType.ADJECTIVE, "Musical", Random.Range(1, 15), "cal"),
                new Word(WordType.ADJECTIVE, "Democr�tico", Random.Range(1, 15), "co"),
                new Word(WordType.ADJECTIVE, "Individual", Random.Range(1, 15), "al"),
                new Word(WordType.ADJECTIVE, "Nacional", Random.Range(1, 15), "al"),
                new Word(WordType.ADJECTIVE, "Regional", Random.Range(1, 15), "al"),
                new Word(WordType.ADJECTIVE, "Mundial", Random.Range(1, 15), "al"),
                new Word(WordType.ADJECTIVE, "Econ�mico", Random.Range(1, 15), "co"),
                new Word(WordType.ADJECTIVE, "Pol�tico", Random.Range(1, 15), "co"),
                new Word(WordType.ADJECTIVE, "Hist�rico", Random.Range(1, 15), "co"),
                new Word(WordType.ADJECTIVE, "Civil", Random.Range(1, 15), "vil"),
                new Word(WordType.ADJECTIVE, "Familiar", Random.Range(1, 15), "ar"),
                new Word(WordType.ADJECTIVE, "Industrial", Random.Range(1, 15), "al"),
                new Word(WordType.ADJECTIVE, "Naval", Random.Range(1, 15), "al"),
                new Word(WordType.ADJECTIVE, "Agr�cola", Random.Range(1, 15), "la"),
                new Word(WordType.ADJECTIVE, "Colombiano", Random.Range(1, 15), "no"),
                new Word(WordType.ADJECTIVE, "Energ�tica", Random.Range(1, 15), "ca"),
                new Word(WordType.ADJECTIVE, "Petrolero", Random.Range(1, 15), "ro"),
                new Word(WordType.ADJECTIVE, "Segundo", Random.Range(1, 15), "do"),
                new Word(WordType.ADJECTIVE, "Triple", Random.Range(1, 15), "ple"),
                new Word(WordType.ADJECTIVE, "Ambos", Random.Range(1, 15), "bos"),
                new Word(WordType.ADJECTIVE, "Juvenil", Random.Range(1, 15), "nil"),
                new Word(WordType.ADJECTIVE, "Comunista", Random.Range(1, 15), "ta"),
                new Word(WordType.ADJECTIVE, "Infantil", Random.Range(1, 15), "il"),
                new Word(WordType.ADJECTIVE, "Capitalista", Random.Range(1, 15), "ta"),
                new Word(WordType.ADJECTIVE, "Renacentista", Random.Range(1, 15), "ta"),
                new Word(WordType.ADJECTIVE, "Fotogr�fico", Random.Range(1, 15), "co"),
                new Word(WordType.ADJECTIVE, "Mucho", Random.Range(1, 15), "cho"),
                new Word(WordType.ADJECTIVE, "Poco", Random.Range(1, 15), "co"),
                new Word(WordType.ADJECTIVE, "Demasiado", Random.Range(1, 15), "do"),
                new Word(WordType.ADJECTIVE, "Suficiente", Random.Range(1, 15), "te"),
                new Word(WordType.ADJECTIVE, "Todo", Random.Range(1, 15), "do"),
                new Word(WordType.ADJECTIVE, "Varios", Random.Range(1, 15), "os"),
                new Word(WordType.ADJECTIVE, "M�s", Random.Range(1, 15), "m�s"),
                new Word(WordType.ADJECTIVE, "Menos", Random.Range(1, 15), "nos"),
                new Word(WordType.ADJECTIVE, "Alg�n", Random.Range(1, 15), "g�n"),
                new Word(WordType.ADJECTIVE, "Ning�n", Random.Range(1, 15), "g�n"),
                new Word(WordType.ADJECTIVE, "Cierto", Random.Range(1, 15), "to"),
                new Word(WordType.ADJECTIVE, "Ninguno", Random.Range(1, 15), "no"),
                new Word(WordType.ADJECTIVE, "Otro", Random.Range(1, 15), "tro"),
                new Word(WordType.ADJECTIVE, "Semejante", Random.Range(1, 15), "te"),
                new Word(WordType.ADJECTIVE, "Tal", Random.Range(1, 15), "tal"),
                new Word(WordType.ADJECTIVE, "Cada", Random.Range(1, 15), "da"),
                new Word(WordType.ADJECTIVE, "Sendos", Random.Range(1, 15), "os"),
                new Word(WordType.ADJECTIVE, "Cualquier", Random.Range(1, 15), "er"),
                new Word(WordType.ADJECTIVE, "Bastante", Random.Range(1, 15), "te"),
                new Word(WordType.ADJECTIVE, "Ese", Random.Range(1, 15), "ese"),
                new Word(WordType.ADJECTIVE, "Aquel", Random.Range(1, 15), "el"),
                new Word(WordType.ADJECTIVE, "Aquellas", Random.Range(1, 15), "llas"),
                new Word(WordType.ADJECTIVE, "Este", Random.Range(1, 15), "te"),
                new Word(WordType.ADJECTIVE, "Nuestro", Random.Range(1, 15), "tro"),
                new Word(WordType.ADJECTIVE, "Cu�l", Random.Range(1, 15), "�l"),
                new Word(WordType.ADJECTIVE, "Cu�nto", Random.Range(1, 15), "to"),
                new Word(WordType.ADJECTIVE, "Qu�", Random.Range(1, 15), "qu�"),
                new Word(WordType.ADJECTIVE, "Cu�nta", Random.Range(1, 15), "ta"),
                new Word(WordType.ADJECTIVE, "Cuanto", Random.Range(1, 15), "to"),
                new Word(WordType.ADJECTIVE, "Cuyo", Random.Range(1, 15), "yo")
            };

            foreach (string w in wordsVerb)
                availableWords.Add(new Word(WordType.VERB, w, Random.Range(1, 15), w.Substring(w.Length - 2)));


            card = GetCardFromDeck();
            text.text = card.Word.Text;
            points.text = card.Word.Points.ToString();
            special.text = SpecialToString(card.Special);
        }

        string SpecialToString(Effect cardSpecial)
        {
            switch (cardSpecial)
            {
                case Effect.None:
                    return "";
                case Effect.x2:
                    return "X2";
                case Effect.x3:
                    return "X3";
                case Effect.DrawOneExtra:
                    return "+1 Xtra";
                case Effect.DrawTwoExtra:
                    return "+2 Xtra";
            }
            return "";
        }

        Card GetCardFromDeck()
        {
            var word = availableWords[Random.Range(0, availableWords.Count)];
            return new Card(word);
        }
        void OnEnable() {
            eventManager = FindObjectOfType<EventManager>();
            OnCardPlayed += eventManager.PlayCard;
        }

        void OnDestroy() => OnCardPlayed -= eventManager.PlayCard;

        public void SelectCard()
        {
            int PLAYER_ID = 1;
            OnCardPlayed?.Invoke(this, CardPlayedArgs.Create(gameObject, card, PLAYER_ID));
        }
    }
}