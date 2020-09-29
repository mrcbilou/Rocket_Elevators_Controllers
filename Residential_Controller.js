
class Column {
    constructor(floorAmount, elevatorAmount) {
        console.log('Column constructor', "ON");
        this.floorAmount = floorAmount;
        this.elevatorAmount = elevatorAmount;
        this.elevatorList=[];
        this.callButtonList=[];
        
        

        
        console.log("NEW ELEVATORS CREATED");
        var i=1;
        while(  i <= elevatorAmount ) {

            let elevator = new Elevator (this.currentFloor, "idle",  this.floorAmount);
            this.elevatorList.push(elevator);
            i = i+1;
        }
        console.log("ELEVATOR STATUS AND POSITION");
        console.table(this.elevatorList);


        console.log('CALL BUTTON LIST');
        // call Button List
        
        for (var i = 1; i <= this.floorAmount; i++){
            
            if(i === 1){
            this.callButtonList.push(new CallButton ( "up", "off"));
        }   if (i === 10){
            this.callButtonList.push(new CallButton ( "down", "off"));
        }   else {
            this.callButtonList.push(new CallButton ( "up", "off"));
            this.callButtonList.push(new CallButton ( "down", "off"));
        }
            
        }
        console.table(this.callButtonList);



        
    }
}

class Elevator {
    constructor ( currentFloor, currentDirection, floorAmount) {
        
        this.currentFloor = currentFloor;
        this.floorAmount = floorAmount;
        this.currentDirection = currentDirection;
        this.floorButtonList=[];

        // floor selection button
        console.log("FLOOR SELECTION BUTTON LIST");

        for(var i = 1; i <= floorAmount; i++){
            
            this.floorButtonList.push(new FloorButton (i, "off", 1));
        }
        console.table(this.floorButtonList);

    }
  
        
}
    


class CallButton {
    constructor (direction, status){
        this.direction = direction;
        this.status = status;

        
        
    }

}

class FloorButton {
    constructor (floorid, status){
        this.status=status;
        this.floorid= floorid;
    }

}


var column1 = new Column(10, 2 );
var elevator1 = new Elevator( 2, "idle", 10);
var elevator2 = new Elevator( 7, "idle", 10);
