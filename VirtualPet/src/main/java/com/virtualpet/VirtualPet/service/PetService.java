package com.virtualpet.VirtualPet.service;

import org.springframework.beans.factory.annotation.Value;
import org.springframework.stereotype.Service;

@Service
public class PetService {

    @Value("${pet.name}")
    private String name;

    @Value("${pet.age}")
    private int age;

    @Value("${pet.favoriteToy}")
    private String favoriteToy;

    public String getName() {
        return name;
    }

    public int getAge() {
        return age;
    }

    public String getFavoriteToy() {
        return favoriteToy;
    }
}
