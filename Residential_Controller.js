
class Column {
    constructor(floorAmount, elevatorAmount) {
        console.log('Column constructor', floorAmount);
        this.floorAmount = floorAmount;
        this.elevatorAmount = elevatorAmount;
        this.elevatorList=[];
        this.callButtonList=[];

        
        var i=1;
        while(  i <= elevatorAmount ) {
            console.log('CREATE AN ELEVATOR', i);
            let elevator = new Elevator (i, "idle", 2, this.floorAmount);
            this.elevatorList.push(elevator);
            i = i+1;
        }
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
    constructor (status, currentFloor, floorAmount) {
        this.status = status;
        this.currentFloor = currentFloor;
        this.floorAmount = floorAmount;
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


var column1 = new Column(10, 2);
var elevator1 = new Elevator("Idle", 2, 10);
