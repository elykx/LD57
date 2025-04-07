
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SessionData : MonoBehaviour
{
    public static SessionData Instance;
    public int currentLevel = 1;
    public List<Card> InDeckCards = new List<Card>();
    // public List<Card> AvailableCards = new List<Card>();
    public Dictionary<string, System.Func<Card>> AvailableCards = new();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        Sprite[] cardSprites = Resources.LoadAll<Sprite>("Sprites/cards");
        AvailableCards.Add("Cyber Slash", () => new AttackCard("Cyber Slash", 2, 3,
            "> injecting payload...\n> target://node_0324 accessed\n> executing [cyber_slash.vx]\n> ███████████████▓▒░ done.\n> damage packet delivered: 27μB\n> node integrity reduced.",
            2, cardSprites.FirstOrDefault(s => s.name == "c_bandBoost"),
            "Name = Cyber Slash\nCost = 2\nDamage = 3\nA powerful attack that inflicts damage and reduces target node's integrity."));
        AvailableCards.Add("Ping", () => new ProgressCard("Ping", 1,
            "> dispatching ping...\n> contacting node://0324...\n> latency: 42ms — packet received\n> fingerprint: SHA-1:ac7b...f59a\n> node responsive. Trace started.",
            3, cardSprites.FirstOrDefault(s => s.name == "c_ping"),
            "Name = Ping\nCost = 1\nProgress = 3\nA simple command to test node connectivity."));
        AvailableCards.Add("Data Harvest", () => new ProgressCard("Data Harvest", 2,
            "> establishing siphon link...\n> accessing datastore://corp_mainframe\n> initializing [harvest_routine.py]\n> ██▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒ done (3.2s)\n> collected: 54μB // decrypted: 38μB\n> data uploaded to vault://local_node"
            , 5, cardSprites.FirstOrDefault(s => s.name == "c_trace"),
            "Name = Data Harvest\nCost = 2\nProgress = 5\nA command to gather data from a target node."));
        AvailableCards.Add("Firewall", () => new DefenseCard("Firewall", 3, 5,
            "> deploying defense module...\n> initiating firewall.shield\n> binding to port 443\n> incoming threats: redirected\n> [OK] active protection enabled (v2.1.4)"
            , 1, cardSprites.FirstOrDefault(s => s.name == "c_firewall"),
            "Name = Firewall\nCost = 3\nDefense = 5\nA firewall that blocks incoming threats."));
        AvailableCards.Add("Backdoor", () => new AttackCard("Backdoor", 1, 2,
            "> injecting stealth script...\n> tunneling via port:8080\n> installing [backdoor.vbs]...\n> access granted: low-level perms\n> persistent access established."
            , 1, cardSprites.FirstOrDefault(s => s.name == "c_backdoor"),
            "Name = Backdoor\nCost = 1\nDamage = 2\nA backdoor that allows remote access to a target node."));
        AvailableCards.Add("Encryption", () => new AttackCard("Encryption", 3, 4,
            "> encrypting all outbound traffic...\n> generating RSA keys (2048b)...\n> keys shared with node:trusted_vault\n> encryption enabled: AES-CTR\n> comms obfuscated."
            , 1, cardSprites.FirstOrDefault(s => s.name == "c_encrypt"),
            "Name = Encryption\nCost = 3\nDamage = 4\nA command to encrypt all outbound traffic."));
        AvailableCards.Add("Worm Injection", () => new AttackCard("Worm Injection", 2, 3,
            "> compiling worm entity...\n> injecting worm into node://dev_17\n> process masked as 'sys_update.exe'\n> ███████████▓▒░ injection complete\n> replicating across subnet..."
            , 1, cardSprites.FirstOrDefault(s => s.name == "c_worm"),
            "Name = Worm Injection\nCost = 2\nDamage = 3\nA command to inject a worm into a target node."));
        AvailableCards.Add("Delay", () => new DefenseCard("Delay", 2, 4,
            "> intercepting packets...\n> injecting delay_script.lag\n> throttling node: 0324 — 400ms\n> bypassing watchdog trigger\n> connection stability compromised."
            , 1, cardSprites.FirstOrDefault(s => s.name == "c_delay"),
            "Name = Delay\nCost = 2\nDefense = 4\nA command to delay a target node's response."));
        AvailableCards.Add("DDoS Attack", () => new AttackCard("DDoS Attack", 2, 4,
            "> initiating distributed overload...\n> botnet nodes engaged: 278\n> flooding node://corp_auth\n> CPU usage: 98% ▲\n> target unresponsive. overload confirmed."
            , 1, cardSprites.FirstOrDefault(s => s.name == "c_attack"),
            "Name = DDoS Attack\nCost = 2\nDamage = 4\nA command to launch a distributed DDoS attack."));

    }

    public Card GetRandomCardFromAvailableCards()
    {

        int randomIndex = Random.Range(0, AvailableCards.Count);
        Card randomCard = AvailableCards.ElementAt(randomIndex).Value();
        return randomCard;
    }

    public void AddCardToAvailable(Card currentCard)
    {
        AvailableCards.Add(currentCard.CardName, () => currentCard);
    }
}