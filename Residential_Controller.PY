""" /***********************************************************************;
* Project           : Residential_Controller
*
* Program name      : Residential_Controller.py
*
* Author            : Louis-Felix Beland
*
* Date created      : 2 October 2020
*
* Purpose           : Programming an algorithm for a Residential Elevator Controller
*
|**********************************************************************/
 """

class Column:
    def __init__(self, floorAmount, elevatorAmount):
        self.floorAmount = floorAmount 
        self.elevatorAmount = elevatorAmount
        self.floorList = []
        self.elevatorList = []
        self.callButtonList = []
        self.floorButtonList = []
        

        i = 1
        while i <= self.elevatorAmount:
            #print('NEW ELEVATORS')
            elevator = Elevator(1, i)
            self.elevatorList.append(elevator)
            i += 1

        # print(self.elevatorList)

        for floorAmount in range(1,11):
            #print(floorAmount)
            floorButton = FloorButton (floorAmount, 'off')
            self.floorButtonList.append(floorButton)

        # print(self.floorButtonList)

        for floorAmount in range(1, 11):
            #print(floorAmount)
            floor = Floor (floorAmount)
            self.floorList.append(floor)

        # print(self.floorButtonList)

        for floor in range(len(self.floorList)):
            
            if floor == 0: 
                callButton = CallButton ('up', 'off')
                self.callButtonList.append(callButton)
            elif floor == 9:
                callButton = CallButton ('down', 'off')
                self.callButtonList.append(callButton)
            else:
                callButton = CallButton ('up , down', 'off')
                self.callButtonList.append(callButton)

        # print(self.callButtonList)

    def RequestElevator(self, RequestedFloor, Direction):
        bestDistance = 99
        bestElevatorCase = 0
        print('FINDING THE BEST ELEVATOR')
        
        for i in range(len(self.elevatorList)):
           
            if Direction == 'up' and self.elevatorList[i].currentDirection == 'up' and self.elevatorList[i].currentFloor <= RequestedFloor:
                distance = abs(self.elevatorList[i].currentFloor - RequestedFloor)
                if distance < bestDistance:
                    bestDistance = distance
                    bestElevatorCase = self.elevatorList[i]
                    
            elif Direction == 'down' and self.elevatorList[i].currentDirection == 'down' and self.elevatorList[i].currentFloor >= RequestedFloor:
                distance = abs(self.elevatorList[i].currentFloor - RequestedFloor)
                if distance < bestDistance:
                    bestDistance = distance
                    bestElevatorCase = self.elevatorList[i]
                    
            elif self.elevatorList[i].status == 'idle':
                distance = abs(self.elevatorList[i].currentFloor - RequestedFloor)
                #
                if distance < bestDistance:
                    bestDistance = distance
                    bestElevatorCase = self.elevatorList[i]
                    
            else:
                distance = abs(self.elevatorList[i].currentFloor - RequestedFloor)
                if distance+ self.floorAmount < bestDistance:
                    bestDistance = distance
                    bestElevatorCase = self.elevatorList[i]
                    

        bestElevatorCase.moveElevator(RequestedFloor)
        print('BEST ELEVATOR FOUND')
        print(bestElevatorCase.id)
        print('REQUEST ACCEPTED PICKING SOMEONE UP AT FLOOR')
        print(RequestedFloor)
        print('ELEVATOR STOPPED AT FLOOR ',RequestedFloor, ' \n OPENING DOORS.... \n CLOSING DOORS....')
        return bestElevatorCase

    def RequestFloor (self, elevator,requestedFloor):
        elevator.moveElevator(requestedFloor)
        print('FLOOR SELECTED...     MOVING SOMEONE TO FLOOR' )
        print(requestedFloor)
        print('ELEVATOR STOPPED AT FLOOR ',requestedFloor, ' \n OPENING DOORS.... \n CLOSING DOORS....')

class Elevator:
    def __init__(self, currentFloor, _id):
        self.id = _id
        self.currentFloor = currentFloor
        self.currentDirection = "stop"
        self.status = 'idle'

    def moveElevator (self,targetFloor):
        self.currentFloor = targetFloor
        

class CallButton:
    def __init__(self, direction, status):
        self.direction = direction
        self.status = status

class FloorButton:
    def __init__(self, floorId, status):
        self.floorId = floorId
        self.status = status

class Floor:
    def __init__(self, floorId):
        self.floorId = floorId

# ==========================================================TEST SECTION=================================================

#print('COLUMN')
print('---------------SCENARIO 1 ------------------')
columntTest1= Column(10,2)
print("Floor Amount :", columntTest1.floorAmount, "|", "Elevator Amount", columntTest1.elevatorAmount)
columntTest1.elevatorList[0].currentDirection = "idle"
columntTest1.elevatorList[0].currentFloor = 2
columntTest1.elevatorList[0].status = "idle"
columntTest1.elevatorList[1].currentDirection = "idle"
columntTest1.elevatorList[1].currentFloor = 6
columntTest1.elevatorList[1].status = "idle"
requestTest1 = columntTest1.RequestElevator(3, "up")
columntTest1.RequestFloor(requestTest1, 7)

print('---------------SCENARIO 2 ------------------')
columntTest2= Column(10,2)
print("Floor Amount :", columntTest2.floorAmount, "|", "Elevator Amount", columntTest2.elevatorAmount)
columntTest2.elevatorList[0].currentDirection = "idle"
columntTest2.elevatorList[0].currentFloor = 10
columntTest2.elevatorList[0].status = "idle"
columntTest2.elevatorList[1].currentDirection = "idle"
columntTest2.elevatorList[1].currentFloor = 3
columntTest2.elevatorList[1].status = "idle"
requestTest2 = columntTest2.RequestElevator(1, 'up')
columntTest2.RequestFloor(requestTest2, 6)
requestTest2 = columntTest2.RequestElevator(3,'up')
columntTest2.RequestFloor(requestTest2, 5)
requestTest2 =  columntTest2.RequestElevator(10, 'down')
columntTest2.RequestFloor(requestTest2, 2)

print('---------------SCENARIO 3 ------------------')
columntTest3= Column(10,2)
print("Floor Amount :", columntTest3.floorAmount, "|", "Elevator Amount", columntTest3.elevatorAmount)
columntTest3.elevatorList[0].currentDirection = "idle"
columntTest3.elevatorList[0].currentFloor = 10
columntTest3.elevatorList[0].status = "idle"
columntTest3.elevatorList[1].currentDirection = "up"
columntTest3.elevatorList[1].currentFloor = 6
columntTest3.elevatorList[1].status = "moving"
requestTest3 = columntTest3.RequestElevator(3, "down")
columntTest3.RequestFloor(requestTest3, 2)
columntTest3.elevatorList[1].currentDirection = "idle"
columntTest3.elevatorList[1].status = "idle"
requestTest3 = columntTest3.RequestElevator(10, "down")
columntTest3.RequestFloor(requestTest3, 3)







