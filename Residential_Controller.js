
class Column {
    constructor(floorAmount, elevatorAmount) {
        console.log('Column constructor', "ON");
        this.floorAmount = floorAmount;
        this.elevatorAmount = elevatorAmount;
        this.elevatorList=[];
        this.callButtonList=[];
        this.requestList=[];
        this.floorButtonList=[];
       

        
        // floor selection button
        console.log("FLOOR SELECTION BUTTON LIST");

        for(var i = 1; i <= floorAmount; i++){
            
            this.floorButtonList.push(new FloorButton (i, "off", 1));
        }
        console.table(this.floorButtonList);
        
        
        console.log("NEW ELEVATORS CREATED");
        var i=1;
        while(  i <= elevatorAmount ) {

            let elevator = new Elevator(i, 1,"none","idle");
            this.elevatorList.push(elevator);
            i = i+1;
        }
        console.log("ELEVATOR STATUS AND POSITION");
        console.table(this.elevatorList);


 
      
        

        console.log('CALL BUTTON LIST');
        // call Button List
        
        for (var i = 1; i <= this.floorAmount; i++){
            
            if(i === 1){
            this.callButtonList.push(new CallButton ( "up", "off",i-1));
        }   if (i === 10){
            this.callButtonList.push(new CallButton ( "down", "off",10));
        }   else {
            this.callButtonList.push(new CallButton ( "up", "off" ,i));
            this.callButtonList.push(new CallButton ( "down", "off", i));
        }
            
        }
        console.table(this.callButtonList);
        

        
         
      
        console.log(" FINDING BEST ELEVATOR");
    }
    RequestElevator(RequestedFloor, Direction) {
        
        let bestElevatorCase = null;
        let distance = 0;
        let bestDistance =99;
        
        for (var i= 0 ; i < this.elevatorList.length; i++){
            
            //console.log(distance);
            //console.log(this.elevatorList[i].Direction);
            //console.log(Direction);
            if (Direction === "up" && this.elevatorList[i].Direction === "up" && this.elevatorList[i].currentFloor <= RequestedFloor){
                    distance = Math.abs(this.elevatorList[i].currentFloor - RequestedFloor);
                
                if(distance < bestDistance){
                    bestDistance= distance;
                    bestElevatorCase= this.elevatorList[i]; 
                }  
            }
            else if (Direction === "down" && this.elevatorList[i].Direction === "down" && this.elevatorList[i].currentFloor >= RequestedFloor){
                    distance = Math.abs(this.elevatorList[i].currentFloor - RequestedFloor); 
                if(distance < bestDistance){
                    bestDistance= distance;
                    bestElevatorCase= this.elevatorList[i]; 
                } 
            }
        }
        if(bestElevatorCase != null){
                // calls a function that triggers when the best elvator is found
                console.log("COLUMN FOUND AN ELEVATOR")
                console.log(bestElevatorCase);
                bestElevatorCase.moveELevator(RequestedFloor);               
        }
        else {
            for (var j= 0 ; j < this.elevatorList.length; j++){
                if (this.elevatorList[j].Direction ==="none") {
                    distance = Math.abs(this.elevatorList[j].currentFloor - RequestedFloor);
                    if(distance < bestDistance){
                        bestDistance= distance;
                        bestElevatorCase= this.elevatorList[j]; 
                    }
                }
            }
            if (bestElevatorCase != null) {
                console.log("COLUMN FOUND the correct AN ELEVATOR")
                console.log(bestElevatorCase);
                bestElevatorCase.moveELevator(RequestedFloor);
                // bestElevatorCase is an Elevator
                // calls a function that triggers when the best elvator is found
            }
        }
    }
    RequestFloor(bestElevatorCase, RequestedFloor){
        bestElevatorCase.push.elevatorList[0];
        this.elevatorList[0].moveELevator(RequestedFloor);
        console.log("A FLOOR HAS BEEN REQUESTED ... \n MOVING TO FLOOR: " + RequestedFloor);
    }

}

class Elevator {
    constructor ( elevatorId, currentFloor, Direction, currentStatus ) {
        this.elevatorId = elevatorId;
        this.currentFloor = currentFloor;
        this.Direction = Direction;
        this.currentStatus = currentStatus;
        
        this.requestList = [];

        
        for(var i = 0; i <= this.RequestedFloor; i++){
            this.requestList.push(new Request ( i,"received"));
        }
        console.log("REQUEST LIST");
        console.table(this.requestList);
    }
    moveELevator(targetFloor){
        this.currentFloor = targetFloor;
        console.log("ELEVATOR IS PICKING SOMEONE UP AT " + this.currentFloor);
    }     
    

    

}
class CallButton {
    constructor (direction, status,floorId){
        this.direction = direction;
        this.status = status;
        this.floorId=floorId
        
        
    }
    
}

class FloorButton {
    constructor (floorid, status,RequestedFloor){
        this.status=status;
        this.floorid= floorid;
        this.RequestedFloor = RequestedFloor;
    }

    

}

class Request {
    constructor (floorId,status){
    this.floorId= floorId
    this.status =status
}
}



//var column1 = new Column(10, 2 );
//var elevator1 = new Elevator( 2, "idle", 10);
//var elevator2 = new Elevator( 7, "idle", 10);

//TEST1
var columnTest1 = new Column(10, 2);
columnTest1.elevatorList[0].elevatorId = "A";
columnTest1.elevatorList[0].currentFloor = 2;
columnTest1.elevatorList[0].Direction = 'none';
columnTest1.elevatorList[0].currentStatus = 'none';

columnTest1.elevatorList[1].elevatorId = "B";
columnTest1.elevatorList[1].currentFloor = 6;
columnTest1.elevatorList[1].Direction = 'none';
columnTest1.elevatorList[1].currentStatus = 'none';

columnTest1.callButtonList[5].direction="on";
columnTest1.callButtonList[5].status="up";


columnTest1.RequestElevator(3,"up");
columnTest1.RequestFloor(0, 7)


//TEST2
/*var columnTest1 = new Column(10, 2);
columnTest1.elevatorList[0].elevatorId = "A";
columnTest1.elevatorList[0].currentFloor = 10;
columnTest1.elevatorList[0].Direction = 'none';
columnTest1.elevatorList[0].currentStatus = 'none';

columnTest1.elevatorList[1].elevatorId = "B";
columnTest1.elevatorList[1].currentFloor = 3;
columnTest1.elevatorList[1].Direction = 'none';
columnTest1.elevatorList[1].currentStatus = 'none';
columnTest1.findBestElevator("up",1);*/
