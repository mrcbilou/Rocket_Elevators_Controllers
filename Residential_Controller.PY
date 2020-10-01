class Column:
    def __init__(self, floorAmount, elevatorAmount):
        self.floorAmount = floorAmount 
        self.elevatorAmount = elevatorAmount
        self.elevatorList = []
        self.callButtonList = []
        self.floorButtonList = []

        i = 1
        while i <= self.elevatorAmount:
            print('NEW ELEVATORS')
            elevator = Elevator(1 , 'idle' , floorAmount)
            self.elevatorList.append(elevator)
            i += 1

        print(self.elevatorList)

        for floorAmount in range(10)  :
            print('floor found')
            floorButton = FloorButton (1, 'off')
            self.floorButtonList.append(floorButton)
        
        print(self.floorButtonList)
            
    



class Elevator:
    def __init__(self, currentFloor, currentDirection, floorAmount):
        self.currentFloor = currentFloor
        self.currentDirection = currentDirection
        self.floorAmount = floorAmount



class CallButton:
    def __init__(self, direction, status):
        self.direction = direction
        self.status = status



class FloorButton:
    def __init__(self, floorId, status):
        self.floorId = floorId
        self.status = status







# TEST SECTION

print('COLUMN')
testColumn1 = Column(10,2)
print(testColumn1.floorAmount)
print(testColumn1.elevatorAmount)

print('ELEVATORS')

q1 = Elevator(2, "idle", 10)
print(q1.currentFloor)
print(q1.currentDirection)
print(q1.floorAmount)


floorButton = FloorButton (1,'off')

print('CALL BUTTON')
w1 = CallButton('up , down', "off")
print(w1.direction)
print(w1.status)


print('FLOOR BUTTON')
a1 = FloorButton('1', "off")
print(a1.floorId)
print(a1.status)




# floor button loop
#floorButtonIter = iter(FloorButton)
#for floorAmount in range(9):
 #   print(next(floorButtonIter))

# call button loop 
#for floorAmount in range(9):
 #   if floorAmount == 0:
  #      print(CallButton("up","off"))
   #     print("CallButton","up" , "off")
    #if floorAmount == 9:
     #   print(CallButton("down","off"))
      #  print("CallButton","down" , "off")
   # else:
    #    print(CallButton("up, down","off"))
     #   print("CallButton","up, down" , "off")
    

