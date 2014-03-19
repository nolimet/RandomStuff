using UnityEngine;
using System.Collections;

public class EnergyNode : EnergyBase {

    public int transferRate = 2;

    public void receive(float received)
    {
        Storage += received;
        if (Storage > MaxStorage) Storage = MaxStorage;
    }
    public void sendPower(float sent, float name)
    {
        if(Storage>=sent){
            
        }
        else{

        }
    }
}
