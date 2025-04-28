package com.virtualpet.VirtualPet.config;

import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

import java.text.DecimalFormat;

@Configuration
public class AppConfig {

    @Bean
    public DecimalFormat currencyFormatter() {
        return new DecimalFormat("#,##0.00");
    }
}
