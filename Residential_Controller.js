
/***********************************************************************;
* Project           : Residential_Controller
*
* Program name      : Residential_Controller.js
*
* Author            : Louis-Felix Beland
*
* Date created      : 2 October 2020
*
* Purpose           : Programming an algorithm for a Residential Elevator Controller
*
|**********************************************************************/

class Column {
    constructor(floorAmount, elevatorAmount) {
        console.log('Column constructor', "ON");
        this.floorAmount = floorAmount;
        this.elevatorAmount = elevatorAmount;
        this.elevatorList=[];
        this.callButtonList=[];
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
        let bestElevator = this.findBestElevator(Direction, RequestedFloor);
        bestElevator.moveELevator(RequestedFloor);
        return bestElevator;
    }

    findBestElevator(Direction, RequestedFloor) {

        let bestElevatorCase = null;
        let distance = 0;
        let bestDistance =11;
        
        for (var i = 0; i < this.elevatorList.length; i++) {
            if (Direction === "up" && this.elevatorList[i].Direction === "up" && this.elevatorList[i].currentFloor <= RequestedFloor) {
                distance = Math.abs(this.elevatorList[i].currentFloor - RequestedFloor);

                if (distance < bestDistance) {
                    bestDistance = distance;
                    bestElevatorCase = this.elevatorList[i];
                }
            }
            else if (Direction === "down" && this.elevatorList[i].Direction === "down" && this.elevatorList[i].currentFloor >= RequestedFloor) {
                distance = Math.abs(this.elevatorList[i].currentFloor - RequestedFloor);
                if (distance < bestDistance) {
                    bestDistance = distance;
                    bestElevatorCase = this.elevatorList[i];
                }
            }
        }
        if (bestElevatorCase != null) {
            // calls a function that triggers when the best elvator is found
            console.log("COLUMN FOUND AN ELEVATOR");
            console.log(bestElevatorCase);
        }
        else {
            for (var j = 0; j < this.elevatorList.length; j++) {
                if (this.elevatorList[j].Direction === "none") {
                    distance = Math.abs(this.elevatorList[j].currentFloor - RequestedFloor);
                    if (distance < bestDistance) {
                        bestDistance = distance;
                        bestElevatorCase = this.elevatorList[j];
                    }
                }
            }
            if (bestElevatorCase != null) {
                console.log("COLUMN FOUND the correct ELEVATOR");
                console.log(bestElevatorCase);

                // bestElevatorCase is an Elevator
                // calls a function that triggers when the best elvator is found
            }
        }
        return bestElevatorCase;
    }

    RequestFloor (Elevator ,RequestedFloor){
        this.elevatorList[Elevator].moveELevator(RequestedFloor);
        console.log(" FLOOR SELECTED... \n  MOVING TO FLOOR: " + RequestedFloor, "\n ELEVATOR STOPPED \n OPENING DOORS..... \n CLOSING DOORS....");
    }
}
class Elevator {
    constructor ( elevatorId, currentFloor, Direction, currentStatus ) {
        this.elevatorId = elevatorId;
        this.currentFloor = currentFloor;
        this.Direction = Direction;
        this.currentStatus = currentStatus;
        
    }
    moveELevator(targetFloor){
        this.currentFloor = targetFloor;
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

// ====================================TEST SECTION===========================================

//SCENARIO 1

var columnTest1 = new Column(10, 2);
columnTest1.elevatorList[0].elevatorId = "A";
columnTest1.elevatorList[0].currentFloor = 2;
columnTest1.elevatorList[0].Direction = 'none';
columnTest1.elevatorList[0].currentStatus = 'none';
columnTest1.elevatorList[1].elevatorId = "B";
columnTest1.elevatorList[1].currentFloor = 6;
columnTest1.elevatorList[1].Direction = 'none';
columnTest1.elevatorList[1].currentStatus = 'none';
console.log("SCENARIO 1");
columnTest1.RequestElevator(3,"up");
console.log("ELEVATOR IS PICKING SOMEONE UP AT FLOOR "+ columnTest1.elevatorList[0].currentFloor ,"OPENING DOORS ....... \n CLOSING DOORS ....." );
columnTest1.RequestFloor(0,7);


//SCENARIO 2

var columnTest2 = new Column(10, 2);
columnTest2.elevatorList[0].elevatorId = "A";
columnTest2.elevatorList[0].currentFloor = 10;
columnTest2.elevatorList[0].Direction = 'none';
columnTest2.elevatorList[0].currentStatus = 'none';
columnTest2.elevatorList[1].elevatorId = "B";
columnTest2.elevatorList[1].currentFloor = 3;
columnTest2.elevatorList[1].Direction = 'none';
columnTest2.elevatorList[1].currentStatus = 'none';
console.log("SCENARIO 2");
columnTest2.RequestElevator(1,"up");
console.log("ELEVATOR IS PICKING SOMEONE UP AT FLOOR "+ columnTest2.elevatorList[1].currentFloor ,"OPENING DOORS ....... \n CLOSING DOORS ....." );
columnTest2.RequestElevator(3,"up");
console.log("ELEVATOR IS PICKING SOMEONE UP AT FLOOR "+ columnTest2.elevatorList[1].currentFloor ,"OPENING DOORS ....... \n CLOSING DOORS ....." );
columnTest2.RequestFloor(0,5);
columnTest2.RequestFloor(0,6);
columnTest2.RequestElevator(9,"down");
console.log("ELEVATOR IS PICKING SOMEONE UP AT FLOOR "+ columnTest2.elevatorList[0].currentFloor ,"OPENING DOORS ....... \n CLOSING DOORS ....." );
columnTest2.RequestFloor(1,2);

// SCENARIO 3

var columnTest3 = new Column(10, 2);
columnTest3.elevatorList[0].elevatorId = "A";
columnTest3.elevatorList[0].currentFloor = 10;
columnTest3.elevatorList[0].Direction = 'none';
columnTest3.elevatorList[0].currentStatus = 'none';
columnTest3.elevatorList[1].elevatorId = "B";
columnTest3.elevatorList[1].currentFloor = 6;
columnTest3.elevatorList[1].Direction = 'up';
columnTest3.elevatorList[1].currentStatus = 'moving';
console.log("SCENARIO 3");
columnTest3.RequestElevator(3,"down");
console.log("ELEVATOR IS PICKING SOMEONE UP AT FLOOR "+ columnTest3.elevatorList[0].currentFloor ,"OPENING DOORS ....... \n CLOSING DOORS ....." );
columnTest3.RequestFloor(0,2);
columnTest3.elevatorList[1].Direction = 'none';
columnTest3.elevatorList[1].currentStatus = 'none';
columnTest3.RequestElevator(10,"down");
console.log("ELEVATOR IS PICKING SOMEONE UP AT FLOOR "+ columnTest3.elevatorList[1].currentFloor ,"OPENING DOORS ....... \n CLOSING DOORS ....." );
columnTest3.RequestFloor(1,3);
