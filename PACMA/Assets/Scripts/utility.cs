
namespace Utility
{
    public enum Sentido
    {
        Derecha = 0,
        Izquierda = 1,
        Recto = 2 // Espero no romper nada juejuejue
    }
    public enum Cardinal { 
        North = 0,
        West = 1,
        South = 2,
        East = 3
    }

    public struct Direccion
    {
        public Sentido sentido;
        public int destino; //Esto se cambiar�? Posiblemente
    }
}