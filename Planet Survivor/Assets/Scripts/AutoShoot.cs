using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoShoot : MonoBehaviour
{

    public float shootInterval = 1f; // Intervalo entre os tiros
    public float detectionRange = 10f; // Distância para detectar inimigos
    public GameObject projectilePrefab; // Prefab do projétil
    public Transform firePoint; // Ponto de onde o projétil será disparado

    private void Start()
    {
        StartCoroutine(ShootAtClosestEnemy());
    }

    private IEnumerator ShootAtClosestEnemy()
    {
        while (true)
        {
            GameObject closestEnemy = FindClosestEnemy();

            if (closestEnemy != null)
            {
                Shoot(closestEnemy.transform.position);
            }

            yield return new WaitForSeconds(shootInterval);
        }
    }

    private GameObject FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closestEnemy = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            if (distance < closestDistance && distance <= detectionRange)
            {
                closestDistance = distance;
                closestEnemy = enemy;
            }
        }

        return closestEnemy;
    }

    private void Shoot(Vector2 targetPosition)
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y); // Converte para Vector2
        Vector2 direction = (targetPosition - firePointPosition).normalized;
        projectile.GetComponent<Rigidbody2D>().velocity = direction * 10f;
    }
}


