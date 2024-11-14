from Counter import Counter

class Clock:

    def __init__(self):
        self.second = Counter(name="second")
        self.minute = Counter(name="minute")
        self.hour = Counter(name="hour")
        
    def Tick(self):
        self.second.Increment()
        if self.second.Ticks > 59:
            self.second.Reset()
            self.minute.Increment()

            if self.minute.Ticks > 59:
                self.minute.Reset()
                self.hour.Increment()

                if self.hour.Ticks > 23:
                    self.Reset()

    def Reset(self):
        self.second.Reset()
        self.minute.Reset()
        self.hour.Reset()

    @property
    def Time(self):
        return f"{self.hour.Ticks:02}:{self.minute.Ticks:02}:{self.second.Ticks:02}"