using System;

    public enum PacketType
    {
        //Uptime/diagnostic
        HEARTBEAT,
        
        //General
        MESSAGE,
        
        //Game control
        JOIN_GAME,
        CLIENT_INIT,
        UPDATE_SKIN,
        UPDATE_NAME,
        SPAWN_ENTITY,
        
        
        //Movement
        CLIENT_MOVEMENT_INPUT,
        
    }

