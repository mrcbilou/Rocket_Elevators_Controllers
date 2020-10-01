
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
        

        
         
      /*  for (var request of this.requestList){
            console.log("request !!!!!!")
            
            if (CallButton.status = "on"){
                this.requestList.push(new Request (direction, status));
            }
        }
            
        
        console.table(this.requestList);*/
        console.log(" FINDING BEST ELEVATOR");
    }
   // gives a best elevator but not the good one
    findBestElevator(currentDirection, requestedFloor) {
        
        let bestElevatorCase = null;
        var distanceA = Math.abs(this.elevatorList[0].currentFloor - requestedFloor);
        var distanceB = Math.abs(this.elevatorList[1].currentFloor - requestedFloor);
        console.log(distanceA);
        console.log(distanceB);
        for (var i= 0 ; i < this.elevatorList.length; i++){
           
            
            if (currentDirection === "up" && this.elevatorList[i].currentDirection === "up" && this.elevatorList[i].currentFloor <= requestedFloor){
                bestElevatorCase= this.elevatorList[i];
            }
            else if  (currentDirection === "down" && this.elevatorList[i].currentDirection === "down" && this.elevatorList[i].currentFloor >= requestedFloor){
                bestElevatorCase = this.elevatorList[i];
                
            } 
            else if(currentDirection ==="up" && this.elevatorList[i].currentDirection ==="none" && this.elevatorList[i].currentFloor <= requestedFloor) {
                bestElevatorCase = this.elevatorList[i];
            }
            else if(currentDirection ==="down" && this.elevatorList[i].currentDirection ==="none" && this.elevatorList[i].currentFloor >= requestedFloor) {
                bestElevatorCase = this.elevatorList[i];
            }
            else if(currentDirection ==="up" && this.elevatorList[i].currentDirection ==="none" && this.elevatorList[i].currentFloor >= distanceA) {
                bestElevatorCase = this.elevatorList[i];
            }
            else if(currentDirection ==="down" && this.elevatorList[i].currentDirection ==="none" && this.elevatorList[i].currentFloor <= distanceA) {
                bestElevatorCase = this.elevatorList[i];
            }
            
          
            var bestElevator = bestElevatorCase;
            
        }
        
        console.log(bestElevator);
        return bestElevator;
        
    }
    
        
            
        
        
            
                
        
            
}



class Elevator {
    constructor ( elevatorId, currentFloor, currentDirection, currentStatus,requestedFloor,floorAmount ) {
        this.elevatorId = elevatorId;
        this.currentFloor = currentFloor;
        this.currentDirection = currentDirection;
        this.currentStatus = currentStatus;
        this.requestedFloor =requestedFloor;
        this.floorAmount = floorAmount;
        

    }
    /*moveElevator(currentFloor,currentDirection,requestedFloor,floorAmount) {
      for (for var)      
    }*/
}
    

    


class CallButton {
    constructor (direction, status,floorId){
        this.direction = direction;
        this.status = status;
        this.floorId=floorId
        
        
    }

}

class FloorButton {
    constructor (floorid, status){
        this.status=status;
        this.floorid= floorid;
    }

}



//var column1 = new Column(10, 2 );
//var elevator1 = new Elevator( 2, "idle", 10);
//var elevator2 = new Elevator( 7, "idle", 10);

//TEST1
var columnTest1 = new Column(10, 2);
columnTest1.elevatorList[0].elevatorId = "A";
columnTest1.elevatorList[0].currentFloor = 2;
columnTest1.elevatorList[0].currentDirection = 'none';
columnTest1.elevatorList[0].currentStatus = 'idle';
columnTest1.elevatorList[0].floorAmount = 10;
columnTest1.elevatorList[1].elevatorId = "B";
columnTest1.elevatorList[1].currentFloor = 1;
columnTest1.elevatorList[1].currentDirection = 'none';
columnTest1.elevatorList[1].currentStatus = 'idle';
columnTest1.elevatorList[0].floorAmount = 10;

columnTest1.findBestElevator("up",3);



//columnTest1.requestElevator(3);
  //TEST2


//this.findBestElevator = function(requestedFloor,currentDirection,currentFloor){
 //   while(elevatorAmount=2){
    //    if(currentDirection= "up"){
   //         currentFloor < requestedFloor
     //   }
       // if(currentDirection = "down"){
 //           currentFloor > requestedFloor
   //     }
     //   if (currentDirection = "idle"){

       //     if(currentFloor < 5 ){
         //       return bestElevator;
           // }
       //     if(currentFloor > 5 ){
         //       return bestElevator;
           // }
       // }
   //     return bestElevator;
    //}
// 