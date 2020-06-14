using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cronometro : MonoBehaviour
{

    public GameObject motorCarreterasGo;
    public MotorCarreteras MotorCarreteraScript;

    public float tiempo;
    public float distancia;
    public Text txtTiempo;
    public Text txtDistancia;
    public Text txtDistanciaFinal;

    // Start is called before the first frame update
    void Start()
    {
        motorCarreterasGo = GameObject.Find("MotorCarreteras");
        MotorCarreteraScript = motorCarreterasGo.GetComponent<MotorCarreteras>();

        txtTiempo.text = "2:00";
        txtDistancia.text = "0";

        tiempo = 120;
    }

    // Update is called once per frame
    void Update()
    {
        if (MotorCarreteraScript.inicioJuego == true && MotorCarreteraScript.juegoTerminado == false) 
        { 
            CalculoTiempoDistancia();
        }

        if(tiempo <= 0 && MotorCarreteraScript.juegoTerminado == false)
        {
            MotorCarreteraScript.juegoTerminado = true;
            MotorCarreteraScript.JuegoTerminadoEstados();
            txtDistanciaFinal.text = ((int)distancia).ToString() + " mts";
            txtTiempo.text = "0:00";
        }
    }

    void CalculoTiempoDistancia()
    {
        distancia += Time.deltaTime * MotorCarreteraScript.velocidad;
        txtDistancia.text = ((int)distancia).ToString();

        tiempo -= Time.deltaTime;
        int minutos = (int)tiempo / 60;
        int segundos = (int)tiempo % 60;

        txtTiempo.text = minutos.ToString() + ":" + segundos.ToString().PadLeft(2, '0');
    }
}
