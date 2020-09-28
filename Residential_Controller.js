var elevatorAmount = 2;
var floorAmount = 10;
var minimumFloor = 1;
var maximumFloor = 10;
var direction = "none";
//var currentDirection = "none";
let requestedFloor = 3;


function Column (floorAmount, minimumFloor, maximumFloor) {
    this.floorAmount = floorAmount;
    this.minimumFloor = minimumFloor;
    this.maximumFloor = maximumFloor;
};

var column1 = new Column (10, 1, 10);


function CallButton (directionUp, directionDown) {
   // this.minimumFloor = minimumFloor;
   // this.maximumFloor = maximumFloor;
   // this.floorAmount = floorAmount;
    this.directionUp = directionUp;
    this.directionDown = directionDown;
            
};

if (currentFloor = 10){
    var topCallButon = new CallButton ("none","DOWN");

};
if (currentFloor = 1){
    var bottomCallButton = new CallButton ("UP","none");
};
if (currentFloor = [2,3,4,5,6,7,8,9]){
    var floorCallButton = new CallButton ("UP", "DOWN")
};



var requestedFloor = 3;
var direction = "UP";

function requestElevator(requestedFloor , direction ) {
   
    console.log('requestElevator called');
    console.log('requestedFloor', requestedFloor);
    console.log('direction', direction);
}

requestElevator(3, "UP");

function Elevator (currentDirection , currentFloor){
    this.currentDirection = currentDirection;
    this.currentFloor =currentFloor;
    
};

var elevatorA = new Elevator ("none", 2 );
var elevatorB = new Elevator ("none", 6 );

function createFloorIndicatorList(elevatorAmount, currentFloor){

};

function findBestElevator(requestedFloor, currentDirection, currentFloor) {
    if (currentDirection = "DOWN") {
        requestedFloor < currentFloor

    } 
    else if (currentDirection = "UP"){
        requestedFloor > currentFloor
    }
    return bestElevator
};

//function initialState(callButton, currentFloor, elevatorStatus) {

//};

//function createRequestList(requestedFloor){

//};

function FLoorSelectionButton (floorAmount){
    this.floorAmount = floorAmount;
};

for(floorAmount = 1; floorAmount <= 10; floorAmount++){
    var floorSelectionButton = new FLoorSelectionButton(1)
};


function moveElevator(currentDirection, requestedFloor, currentFloor){

};

function openDoors(doorStatus, currentFloor){

};

