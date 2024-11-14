class Counter:
    def __init__(self, name):
        self.name = name
        self.count = 0
    
    def Increment(self):
        self.count += 1
    
    def Reset(self):
        self.count = 0
    
    @property
    def Name(self):
        return self.name
    
    @Name.setter
    def Name(self, value):
        self.name = value
    
    @property
    def Ticks(self):
        return self.count