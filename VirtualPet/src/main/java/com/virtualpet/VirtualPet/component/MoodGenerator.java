package com.virtualpet.VirtualPet.component;

import org.springframework.stereotype.Component;

import java.util.Arrays;
import java.util.List;
import java.util.Random;

@Component
public class MoodGenerator {
    private final List<String> moods = Arrays.asList("Happy", "Sleepy", "Hungry", "Playful", "Excited");
    private final Random random = new Random();

    public String generateMood() {
        return moods.get(random.nextInt(moods.size()));
    }
}
