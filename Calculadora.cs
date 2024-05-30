namespace EspacioCalculadora;

public class Calculadora
{
    private double dato;

    public Calculadora(int valorInicial)
    {
        dato = valorInicial;
    }

    public void Sumar(double termino)
    {
        dato += termino;
    }

    public void Restar(double termino)
    {
        dato -= termino;
    }

    public void Multiplicar(double termino)
    {
        dato *= termino;
    }

    public void Dividir(double termino)
    {
        if (termino != 0)
        {
            dato /= termino;
        }
        else
        {
            Console.WriteLine("No se puede dividir en 0");
        }
    }

    public void Limpiar()
    {
        dato = 0;
    }

    public double Resultado { get => dato; }
}
public class Operacion
{
    private double resultadoAnterior;
    private double nuevoValor;
    private TipoOperacion operacion;
    private double resultado;
    public enum TipoOperacion
    {
        Suma,
        Resta,
        Multiplicacion,
        Division,
        Limpiar
    }

    public double ResultadoAnterior { get => resultadoAnterior; set => resultadoAnterior = value; }
    public double NuevoValor { get => nuevoValor; set => nuevoValor = value; }
    public TipoOperacion Tipo { get => operacion; set => operacion = value; }

    public double Resultado { get => resultado; set => resultado = value; }

    public Operacion(double resultadoAnterior, double nuevoValor, TipoOperacion operacionTipo, double resultado)
    {
        ResultadoAnterior = resultadoAnterior;
        NuevoValor = nuevoValor;
        Tipo = operacionTipo;
        Resultado = resultado;
    }
}