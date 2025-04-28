package com.virtualpet.VirtualPet.controller;

import com.virtualpet.VirtualPet.component.MoodGenerator;
import com.virtualpet.VirtualPet.service.FormatterService;
import com.virtualpet.VirtualPet.service.PetService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

@RestController
public class PetController {

    @Autowired
    private PetService petService;

    @Autowired
    private MoodGenerator moodGenerator;

    @Autowired
    private FormatterService formatterService;

    @GetMapping("/")
    public String welcomeFromController() {
        return "Welcome to Fluffy's Virtual Pet World!";
    }

    @GetMapping("/pet/info")
    public String info() {
        return petService.getName() + " is " + petService.getAge() + " years old and loves to play with " + petService.getFavoriteToy() + ".";
    }

    @GetMapping("/pet/mood")
    public String mood() {
        return petService.getName() + " is " + moodGenerator.generateMood();
    }

    @PostMapping("pet/play")
    public String play(@RequestBody String play) {
        return petService.getName() + " is playing with " + play  + "!";
    }

    @GetMapping("pet/feed")
    public String FeedAmount(@RequestParam double amount) {
        return "You fed " + petService.getName() + " a treat worth  $" + formatterService.FormatAmount(amount);
    }
}
